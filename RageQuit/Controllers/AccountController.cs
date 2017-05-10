using RageQuit.Models.Data;
using RageQuit.Models.ViewModels.Account;
using RageQuit.Models.ViewModels.Comment;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace RageQuit.Controllers
{
    public class AccountController : Controller
    {
        public ActionResult Index()
        {
            return RedirectToAction("Login");
        }

        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(LoginUserViewModel userLogin)
        {
            if(userLogin == null)
            {
                ModelState.AddModelError("", "Login required");
                return View();
            }
            if (string.IsNullOrWhiteSpace(userLogin.username) || string.IsNullOrWhiteSpace(userLogin.password))
            {
                ModelState.AddModelError("", "Username and Password required");
                return View();
            }
            using(RageQuitContext context = new RageQuitContext())
            {
                if(context.Users.Any(row => row.username.Equals(userLogin.username)))
                {
                    User checkUser = context.Users.First(row => row.username.Equals(userLogin.username) && row.isActive);
                    if(HashHelper.VerifyHash(userLogin.password, "SHA512", checkUser.password))
                    {
                        FormsAuthentication.SetAuthCookie(userLogin.username, userLogin.rememberMe);
                        return Redirect(FormsAuthentication.GetRedirectUrl(userLogin.username, userLogin.rememberMe));
                    }
                }
            }
            ModelState.AddModelError("", "Invalid Username or Password");
            return View();
        }

        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Login");
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(CreateUserViewModel newUser)
        {
            if(!ModelState.IsValid)
            {
                return View(newUser);
            }
            if (newUser == null)
            {
                ModelState.AddModelError("", "User is required");
                return View();
            }
            if(string.IsNullOrWhiteSpace(newUser.username))
            {
                ModelState.AddModelError("", "Username required");
                return View(newUser);
            }
            if(newUser.username.Count() > 25)
            {
                ModelState.AddModelError("", "Username must be less than 25 characters");
                return View(newUser);
            }
            if (string.IsNullOrWhiteSpace(newUser.password))
            {
                ModelState.AddModelError("", "Password required");
                return View(newUser);
            }
            if(newUser.password.Count() > 25)
            {
                ModelState.AddModelError("", "Password must be less than 25 characters");
                return View(newUser);
            }
            if (!newUser.password.Equals(newUser.confirmPassword))
            {
                ModelState.AddModelError("", "Password and Confirm Password fields do not match");
                return View(newUser);
            }
            using (RageQuitContext context = new RageQuitContext())
            {
                if (context.Users.Any(row => row.username.Equals(newUser.username) && row.isActive))
                {
                    ModelState.AddModelError("", "Username already exisits, please pick new Username");
                    newUser.username = "";
                    return View(newUser);
                }
                User newUserDTO = new User()
                {
                    id = context.Users.Count(),
                    username = newUser.username,
                    password = HashHelper.ComputeHash(newUser.password, "SHA512", null),
                    profilePicture = null,
                    dateCreated = DateTime.Now,
                    isAdmin = false,
                    isActive = true
                };
                context.Users.Add(newUserDTO);
                context.SaveChanges();
                return RedirectToAction("Login");
            }
        }

        [HttpGet]
        public ActionResult UserProfile(int Uid = -1)
        {
            User userDTO = new User();
            using (RageQuitContext context = new RageQuitContext())
            {
                if (Uid == -1)
                {
                    List<User> userListDTO = context.Users.Where(row => row.username.Equals(User.Identity.Name)).ToList();
                    foreach (User item in userListDTO)
                    {
                        if (item.isActive)
                        {
                            userDTO = item;
                        }
                    }
                }
                else
                {
                    userDTO = context.Users.FirstOrDefault(row => row.id == Uid);
                }
                UserProfileViewModel userProfileVM = new UserProfileViewModel()
                {
                    username = userDTO.username,
                    profilePicture = userDTO.profilePicture,
                    dateCreated = userDTO.dateCreated,
                    commentVM = new List<UserCommentViewModel>()
                };
                if (userProfileVM.profilePicture == null)
                {
                    userProfileVM.profilePicture = "http://i.imgur.com/BFFYYh0.png";
                }
                List<Rating> ratings = context.Ratings.Where(row => row.userId == userDTO.id).ToList();
                foreach (Rating ratingDTO in ratings)
                {
                    if (ratingDTO.isActive)
                    {
                        userProfileVM.commentVM.Add(new UserCommentViewModel
                        {
                            id = ratingDTO.id,
                            gameId = ratingDTO.gameId,
                            gameTitle = ratingDTO.gameTitle,
                            comment = ratingDTO.comment,
                            isLiked = ratingDTO.isLiked
                        });
                    }
                }
                return View(userProfileVM);
            }
        }

        [HttpGet]
        public ActionResult EditProfilePicture()
        {
            using (RageQuitContext context = new RageQuitContext())
            {
                try {
                    User userProfiles = context.Users.First(row => row.username.Equals(User.Identity.Name) && row.isActive);
                    EditUserProfilePictureViewModel editUserProfilePictureVM = new EditUserProfilePictureViewModel()
                    {
                        id = userProfiles.id,
                        username = userProfiles.username,
                        profilePicture = userProfiles.profilePicture
                    };
                    return View(editUserProfilePictureVM);
                }
                catch(Exception e)
                {
                    return RedirectToAction("Logout");
                }
            }
        }

        [HttpPost]
        public ActionResult EditProfilePicture(EditUserProfilePictureViewModel editUserProfilePictureVM)
        {
            if(!editUserProfilePictureVM.profilePicture.Contains(".jpg") || !editUserProfilePictureVM.profilePicture.Contains(".png"))
            {
                ModelState.AddModelError("", "Profile picture must be of type .jpg or .png");
                return View(editUserProfilePictureVM);
            }
            using(RageQuitContext context = new RageQuitContext())
            {
                User profile = context.Users.Find(editUserProfilePictureVM.id);
                profile.profilePicture = editUserProfilePictureVM.profilePicture;
                context.SaveChanges();
            }
            return RedirectToAction("UserProfile");
        }

        [HttpGet]
        public ActionResult ChangePassword()
        {
            using (RageQuitContext context = new RageQuitContext())
            {
                try {
                    User userProfileDTO = context.Users.First(row => row.username.Equals(User.Identity.Name) && row.isActive);
                    EditUserPasswordViewModel editUserPasswordVM = new EditUserPasswordViewModel()
                    {
                        id = userProfileDTO.id,
                        username = userProfileDTO.username,
                        password = "",
                        newPassword = "",
                        confirmPassword = ""
                    };
                    return View(editUserPasswordVM);
                }
                catch (Exception e)
                {
                    return RedirectToAction("Logout");
                }
            }
        }

        [HttpPost]
        public ActionResult ChangePassword(EditUserPasswordViewModel editUserPasswordVM)
        {
            if(editUserPasswordVM.newPassword != editUserPasswordVM.confirmPassword)
            {
                ModelState.AddModelError("", "New password and confirm new password do not match");
                editUserPasswordVM = resetEditUserPasswordViewModel(editUserPasswordVM);
                return View(editUserPasswordVM);
            }
            using(RageQuitContext context = new RageQuitContext())
            {
                try {
                    User userProfile = context.Users.Find(editUserPasswordVM.id);
                    if (userProfile.password == editUserPasswordVM.password)
                    {
                        userProfile.password = editUserPasswordVM.password;
                        context.SaveChanges();
                        return RedirectToAction("UserProfile");
                    }
                    ModelState.AddModelError("", "Password invalid");
                    editUserPasswordVM = resetEditUserPasswordViewModel(editUserPasswordVM);
                    return View(editUserPasswordVM);
                }
                catch (Exception e)
                {
                    return RedirectToAction("Logout");
                }
            }
        }

        [HttpPost]
        public ActionResult DeleteUser()
        {
            using (RageQuitContext context = new RageQuitContext())
            {
                User userProfileDTO = context.Users.First(row => row.username.Equals(User.Identity.Name) && row.isActive);
                userProfileDTO.isActive = false;
                List<Rating> ratingsListDTO = context.Ratings.Where(row => row.userId == userProfileDTO.id).ToList();
                foreach(Rating ratingDTO in ratingsListDTO)
                {
                    ratingDTO.isActive = false;
                }
            }
            return RedirectToAction("Logout");
        }

        public EditUserPasswordViewModel resetEditUserPasswordViewModel(EditUserPasswordViewModel editUserPasswordVM)
        {
            editUserPasswordVM.password = "";
            editUserPasswordVM.newPassword = "";
            editUserPasswordVM.confirmPassword = "";
            return editUserPasswordVM;
        }
    }
}