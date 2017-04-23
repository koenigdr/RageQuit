using RageQuit.Models.Data;
using RageQuit.Models.ViewModels.Comment;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RageQuit.Controllers
{
    public class CommentController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Create(bool liked, int gmid)
        {
            if(!User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Login", "Account");
            }
            string gmTitle = "";
            using(RageQuitContext context = new RageQuitContext())
            {
                gmTitle = context.Games.FirstOrDefault(row => row.id == gmid).title;
                Rating newRatingDTO = new Rating
                {
                    id = context.Ratings.Count(),
                    isActive = true,
                    isLiked = liked,
                    gameId = gmid,
                    gameTitle = gmTitle,
                    username = User.Identity.Name
                };
                context.Ratings.Add(newRatingDTO);
                context.SaveChanges();
                CommentViewModel commentVM = new CommentViewModel()
                {
                    id = newRatingDTO.id,
                    isLiked = newRatingDTO.isLiked
                };
                return View(commentVM);
            }
        }

        [HttpPost]
        public ActionResult Create(CommentViewModel commentVM)
        {
            using(RageQuitContext context = new RageQuitContext())
            {
                Rating ratingDTO = context.Ratings.FirstOrDefault(row => row.id == commentVM.id);
                List<User> userListDTO = context.Users.Where(row => row.username.Equals(User.Identity.Name)).ToList();
                foreach(User userDTO in userListDTO)
                {
                    if(userDTO.isActive)
                    {
                        ratingDTO.comment = commentVM.comment;
                        ratingDTO.isLiked = commentVM.isLiked;
                        ratingDTO.userId = userDTO.id;
                        ratingDTO.username = userDTO.username;
                        context.SaveChanges();
                    }
                }
                return RedirectToAction("ViewGame", "Game", new { id = ratingDTO.gameId });
            }
        }

        [HttpPost]
        public ActionResult Delete(int commentId, int userId)
        {
            using(RageQuitContext context = new RageQuitContext())
            {
                Rating ratingDTO = context.Ratings.FirstOrDefault(row => row.id == commentId);
                ratingDTO.isActive = false;
                context.SaveChanges();
            }
            return RedirectToAction("OtherUserProfile", "Account", new { id = userId });
        }

        [HttpGet]
        public ActionResult Edit(int commentId)
        {
            using (RageQuitContext context = new RageQuitContext())
            {
                Rating ratingDTO = context.Ratings.FirstOrDefault(row => row.id == commentId);
                CommentViewModel commentVM = new CommentViewModel()
                {
                    id = ratingDTO.id,
                    comment = ratingDTO.comment,
                    isLiked = ratingDTO.isLiked
                };
                return View(commentVM);
            }
        }

        [HttpPost]
        public ActionResult Edit(CommentViewModel commentVM)
        {
            using(RageQuitContext context = new RageQuitContext())
            {
                Rating ratingDTO = context.Ratings.FirstOrDefault(row => row.id == commentVM.id);
                ratingDTO.comment = commentVM.comment;
                ratingDTO.isLiked = commentVM.isLiked;
                return RedirectToAction("OtherUserProfile", "Account", new { id = ratingDTO.userId });
            }
        }

        [HttpPost]
        public ActionResult Update(bool liked, int gmId)
        {
            using(RageQuitContext context = new RageQuitContext())
            {
                int userId = -1;
                List<User> userListDTO = context.Users.Where(row => row.username.Equals(User.Identity.Name)).ToList();
                foreach(User userDTO in userListDTO)
                {
                    if(userDTO.isActive)
                    {
                        userId = userDTO.id;
                        break;
                    }
                }
                List<Rating> listRatingDTO = context.Ratings.Where(row => row.gameId == gmId).ToList();
                foreach(Rating ratingDTO in listRatingDTO)
                {
                    if(ratingDTO.userId == userId)
                    {
                        if(ratingDTO.isActive)
                        {
                            ratingDTO.isLiked = liked;
                            context.SaveChanges();
                            break;
                        }
                    }
                }
                return RedirectToAction("ViewGame", "Game", new { id = gmId });
            }
        }
    }
}