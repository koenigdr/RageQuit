using RageQuit.Models.Data;
using RageQuit.Models.ViewModels.Comment;
using RageQuit.Models.ViewModels.Game;
using RageQuit.Models.ViewModels.Home;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RageQuit.Controllers
{
    public class GameController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        [Authorize(Roles = "Admin")]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public ActionResult Create(CreateGameViewModel createGameVM)
        {
            if (!ModelState.IsValid)
            {
                return View(createGameVM);
            }
            if (createGameVM == null)
            {
                ModelState.AddModelError("", "Game is required");
                return View();
            }
            if (string.IsNullOrWhiteSpace(createGameVM.title))
            {
                ModelState.AddModelError("", "Title required");
                return View(createGameVM);
            }
            using (RageQuitContext context = new RageQuitContext())
            {
                Game newGameDTO = new Game()
                {
                    id = context.Games.Count(),
                    title = createGameVM.title,
                    description = createGameVM.description,
                    developer = createGameVM.developer,
                    coverArt = createGameVM.coverArt,
                    publisher = createGameVM.publisher,
                    releaseDate = createGameVM.releaseDate,
                    isAction = false,
                    isAdventure = false,
                    isFighting = false,
                    isFlying = false,
                    isParty = false,
                    isPlatformer = false,
                    isPuzzle = false,
                    isRacing = false,
                    isRolePlaying = false,
                    isMMO = false,
                    isShooter = false,
                    isSimulation = false,
                    isSport = false,
                    isStealth = false,
                    isStrategy = false,
                    isSurvivalHorror = false,
                    isOnSwitch = false,
                    isOnXboxOne = false,
                    isOnPS4 = false,
                    isOnPC = false,
                    isOnMac = false,
                    isOnNew3DS = false,
                    isOnWiiU = false,
                    isOnXbox360 = false,
                    isOnPS3 = false,
                    isOnWii = false,
                    isOn3DS = false,
                    isOnVita = false,
                    isOnDS = false,
                    isOnPSP = false,
                    isOnIPhone = false,
                    isOnAndroid = false,
                    isOnGameboyAdvanced = false,
                    isOnXbox = false,
                    isOnPlaystation2 = false,
                    isOnGameCube = false,
                    isOnPlaystation = false,
                    isOnNintendo64 = false,
                    isOnNGage = false,
                    isOnDreamcast = false,
                    isOnGameboy = false,
                    isActive = true
                };
                context.Games.Add(newGameDTO);
                context.SaveChanges();
                return RedirectToAction("AddGenres", new { gameId = newGameDTO.id });
            }
        }

        [HttpGet]
        [Authorize(Roles = "Admin")]
        public ActionResult AddGenres(int gameId)
        {
            using (RageQuitContext context = new RageQuitContext())
            {
                Game gameDTO = context.Games.FirstOrDefault(row => row.id == gameId);
                SelectGameGenresViewModel selectGameGenresVM = new SelectGameGenresViewModel()
                {
                    id = gameId,
                    isAction = gameDTO.isAction,
                    isAdventure = gameDTO.isAdventure,
                    isFighting = gameDTO.isFighting,
                    isFlying = gameDTO.isFlying,
                    isMMO = gameDTO.isMMO,
                    isParty = gameDTO.isParty,
                    isPlatformer = gameDTO.isPlatformer,
                    isPuzzle = gameDTO.isPuzzle,
                    isRacing = gameDTO.isRacing,
                    isRolePlaying = gameDTO.isRolePlaying,
                    isShooter = gameDTO.isShooter,
                    isSimulation = gameDTO.isSimulation,
                    isSport = gameDTO.isSport,
                    isStealth = gameDTO.isStealth,
                    isStrategy = gameDTO.isStrategy,
                    isSurvivalHorror = gameDTO.isSurvivalHorror
                };
                return View(selectGameGenresVM);
            }
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public ActionResult AddGenres(SelectGameGenresViewModel selectGameGenresVM)
        {
            using (RageQuitContext context = new RageQuitContext())
            {
                Game gameDTO = context.Games.First(row => row.id == selectGameGenresVM.id);
                gameDTO.isAction = selectGameGenresVM.isAction;
                gameDTO.isAdventure = selectGameGenresVM.isAdventure;
                gameDTO.isFighting = selectGameGenresVM.isFighting;
                gameDTO.isFlying = selectGameGenresVM.isFlying;
                gameDTO.isMMO = selectGameGenresVM.isMMO;
                gameDTO.isParty = selectGameGenresVM.isParty;
                gameDTO.isPlatformer = selectGameGenresVM.isPlatformer;
                gameDTO.isPuzzle = selectGameGenresVM.isPuzzle;
                gameDTO.isRacing = selectGameGenresVM.isRacing;
                gameDTO.isRolePlaying = selectGameGenresVM.isRolePlaying;
                gameDTO.isShooter = selectGameGenresVM.isShooter;
                gameDTO.isSimulation = selectGameGenresVM.isSimulation;
                gameDTO.isSport = selectGameGenresVM.isSport;
                gameDTO.isStealth = selectGameGenresVM.isStealth;
                gameDTO.isStrategy = selectGameGenresVM.isStrategy;
                gameDTO.isSurvivalHorror = selectGameGenresVM.isSurvivalHorror;
                context.SaveChanges();
                return RedirectToAction("AddSystems", new { gameId = selectGameGenresVM.id });
            }
        }

        [HttpGet]
        [Authorize(Roles = "Admin")]
        public ActionResult AddSystems(int gameId)
        {
            using (RageQuitContext context = new RageQuitContext())
            {
                Game gameDTO = context.Games.First(row => row.id == gameId);
                SelectGameSystemsViewModel selectGameSystemsVM = new SelectGameSystemsViewModel()
                {
                    id = gameDTO.id,
                    isOn3DS = gameDTO.isOn3DS,
                    isOnAndroid = gameDTO.isOnAndroid,
                    isOnDreamcast = gameDTO.isOnDreamcast,
                    isOnDS = gameDTO.isOnDS,
                    isOnGameboy = gameDTO.isOnGameboy,
                    isOnGameboyAdvanced = gameDTO.isOnGameboyAdvanced,
                    isOnGameCube = gameDTO.isOnGameCube,
                    isOnIPhone = gameDTO.isOnIPhone,
                    isOnMac = gameDTO.isOnMac,
                    isOnNew3DS = gameDTO.isOnNew3DS,
                    isOnNGage = gameDTO.isOnNGage,
                    isOnNintendo64 = gameDTO.isOnNintendo64,
                    isOnPC = gameDTO.isOnPC,
                    isOnPlaystation = gameDTO.isOnPlaystation,
                    isOnPlaystation2 = gameDTO.isOnPlaystation2,
                    isOnPS3 = gameDTO.isOnPS3,
                    isOnPS4 = gameDTO.isOnPS4,
                    isOnPSP = gameDTO.isOnPSP,
                    isOnSwitch = gameDTO.isOnSwitch,
                    isOnVita = gameDTO.isOnVita,
                    isOnWii = gameDTO.isOnWii,
                    isOnWiiU = gameDTO.isOnWiiU,
                    isOnXbox = gameDTO.isOnXbox,
                    isOnXbox360 = gameDTO.isOnXbox360,
                    isOnXboxOne = gameDTO.isOnXboxOne
                };
                return View(selectGameSystemsVM);
            }
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public ActionResult AddSystems(SelectGameSystemsViewModel selectGameSystemsVM)
        {
            using(RageQuitContext context = new RageQuitContext())
            {
                Game gameDTO = context.Games.FirstOrDefault(row => row.id == selectGameSystemsVM.id);
                gameDTO.isOn3DS = selectGameSystemsVM.isOn3DS;
                gameDTO.isOnAndroid = selectGameSystemsVM.isOnAndroid;
                gameDTO.isOnDreamcast = selectGameSystemsVM.isOnDreamcast;
                gameDTO.isOnDS = selectGameSystemsVM.isOnDS;
                gameDTO.isOnGameboy = selectGameSystemsVM.isOnGameboy;
                gameDTO.isOnGameboyAdvanced = selectGameSystemsVM.isOnGameboyAdvanced;
                gameDTO.isOnGameCube = selectGameSystemsVM.isOnGameCube;
                gameDTO.isOnIPhone = selectGameSystemsVM.isOnIPhone;
                gameDTO.isOnMac = selectGameSystemsVM.isOnMac;
                gameDTO.isOnNew3DS = selectGameSystemsVM.isOnNew3DS;
                gameDTO.isOnNGage = selectGameSystemsVM.isOnNGage;
                gameDTO.isOnNintendo64 = selectGameSystemsVM.isOnNintendo64;
                gameDTO.isOnPC = selectGameSystemsVM.isOnPC;
                gameDTO.isOnPlaystation = selectGameSystemsVM.isOnPlaystation;
                gameDTO.isOnPlaystation2 = selectGameSystemsVM.isOnPlaystation2;
                gameDTO.isOnPS3 = selectGameSystemsVM.isOnPS3;
                gameDTO.isOnPS4 = selectGameSystemsVM.isOnPS4;
                gameDTO.isOnPSP = selectGameSystemsVM.isOnPSP;
                gameDTO.isOnSwitch = selectGameSystemsVM.isOnSwitch;
                gameDTO.isOnVita = selectGameSystemsVM.isOnVita;
                gameDTO.isOnWii = selectGameSystemsVM.isOnWii;
                gameDTO.isOnWiiU = selectGameSystemsVM.isOnWiiU;
                gameDTO.isOnXbox = selectGameSystemsVM.isOnXbox;
                gameDTO.isOnXbox360 = selectGameSystemsVM.isOnXbox360;
                gameDTO.isOnXboxOne = selectGameSystemsVM.isOnXboxOne;
                context.SaveChanges();
                return RedirectToAction("Index", "Home");
            }
        }

        [HttpGet]
        public ActionResult ViewGame(int id)
        {
            using(RageQuitContext context = new RageQuitContext())
            {
                Game gameDTO = context.Games.FirstOrDefault(row => row.id == id);
                GameViewModel gameVM = new GameViewModel()
                {
                    id = gameDTO.id,
                    title = gameDTO.title,
                    description = gameDTO.description,
                    coverArt = gameDTO.coverArt,
                    developer = gameDTO.developer,
                    publisher = gameDTO.publisher,
                    releaseDate = gameDTO.releaseDate.Date,
                    userHasRated = false,
                    userLiked = false,
                    commentVM = new List<GameCommentViewModel>(),
                    hasReleased = false,
                    rating = -1
                };
                if(DateTime.Compare(DateTime.Now, gameVM.releaseDate) >= 0)
                {
                    gameVM.hasReleased = true;
                }
                if(gameDTO.isAction)
                {
                    gameVM.genres += "Action | ";
                }
                if(gameDTO.isAdventure)
                {
                    gameVM.genres += "Adventure | ";
                }
                if(gameDTO.isFighting)
                {
                    gameVM.genres += "Fighting | ";
                }
                if(gameDTO.isFlying)
                {
                    gameVM.genres += "Flying | ";
                }
                if(gameDTO.isMMO)
                {
                    gameVM.genres += "MMO | ";
                }
                if(gameDTO.isOn3DS)
                {
                    gameVM.systems += "3DS | ";
                }
                if(gameDTO.isOnAndroid)
                {
                    gameVM.systems += "Android | ";
                }
                if(gameDTO.isOnDreamcast)
                {
                    gameVM.systems += "Dreamcase | ";
                }
                if(gameDTO.isOnDS)
                {
                    gameVM.systems += "DS | ";
                }
                if(gameDTO.isOnGameboy)
                {
                    gameVM.systems += "Gameboy | ";
                }
                if(gameDTO.isOnGameboyAdvanced)
                {
                    gameVM.systems += "Gameboy Advanced | ";
                }
                if(gameDTO.isOnGameCube)
                {
                    gameVM.systems += "GameCube | ";
                }
                if(gameDTO.isOnIPhone)
                {
                    gameVM.systems += "IPhone | ";
                }
                if(gameDTO.isOnMac)
                {
                    gameVM.systems += "Mac | ";
                }
                if(gameDTO.isOnNew3DS)
                {
                    gameVM.systems += "New 3DS | ";
                }
                if(gameDTO.isOnNGage)
                {
                    gameVM.systems += "N Gage | ";
                }
                if(gameDTO.isOnNintendo64)
                {
                    gameVM.systems += "Nintendo 64 | ";
                }
                if(gameDTO.isOnPC)
                {
                    gameVM.systems += "PC | ";
                }
                if(gameDTO.isOnPlaystation)
                {
                    gameVM.systems += "Playstation | ";
                }
                if(gameDTO.isOnPlaystation2)
                {
                    gameVM.systems += "Playstation 2 | ";
                }
                if(gameDTO.isOnPS3)
                {
                    gameVM.systems += "Playstation 3 | ";
                }
                if(gameDTO.isOnPS4)
                {
                    gameVM.systems += "Playstation 4 | ";
                }
                if(gameDTO.isOnPSP)
                {
                    gameVM.systems += "PSP | ";
                }
                if(gameDTO.isOnSwitch)
                {
                    gameVM.systems += "Switch | ";
                }
                if(gameDTO.isOnVita)
                {
                    gameVM.systems += "Playstation Vita | ";
                }
                if(gameDTO.isOnWii)
                {
                    gameVM.systems += "Wii | ";
                }
                if(gameDTO.isOnWiiU)
                {
                    gameVM.systems += "Wii U | ";
                }
                if(gameDTO.isOnXbox)
                {
                    gameVM.systems += "Xbox | ";
                }
                if(gameDTO.isOnXbox360)
                {
                    gameVM.systems += "Xbox 360 | ";
                }
                if(gameDTO.isOnXboxOne)
                {
                    gameVM.systems += "Xbox One | ";
                }
                if(gameDTO.isParty)
                {
                    gameVM.genres += "Party | ";
                }
                if(gameDTO.isPlatformer)
                {
                    gameVM.genres += "Platformers | ";
                }
                if(gameDTO.isPuzzle)
                {
                    gameVM.genres += "Puzzle | ";
                }
                if(gameDTO.isRacing)
                {
                    gameVM.genres += "Racing | ";
                }
                if(gameDTO.isRolePlaying)
                {
                    gameVM.genres += "Role Playing | ";
                }
                if(gameDTO.isShooter)
                {
                    gameVM.genres += "Shooter | ";
                }
                if(gameDTO.isSimulation)
                {
                    gameVM.genres += "Simulation | ";
                }
                if(gameDTO.isSport)
                {
                    gameVM.genres += "Sport | ";
                }
                if(gameDTO.isStealth)
                {
                    gameVM.genres += "Stealth | ";
                }
                if(gameDTO.isStrategy)
                {
                    gameVM.genres += "Strategy | ";
                }
                if(gameDTO.isSurvivalHorror)
                {
                    gameVM.genres += "Survival Horror | ";
                }
                if (gameVM.hasReleased)
                {
                    List<Rating> ratings = context.Ratings.Where(row => row.gameId == gameDTO.id && row.isActive).ToList();
                    int likeCount = 0;
                    foreach (Rating ratingDTO in ratings)
                    {
                        gameVM.commentVM.Add(new GameCommentViewModel
                        {
                            id = ratingDTO.id,
                            userId = ratingDTO.userId,
                            username = ratingDTO.username,
                            comment = ratingDTO.comment,
                            isLiked = ratingDTO.isLiked
                        });
                        if (ratingDTO.username.Equals(User.Identity.Name))
                        {
                            gameVM.userHasRated = true;
                            gameVM.userLiked = ratingDTO.isLiked;
                        }
                        if (ratingDTO.isLiked)
                        {
                            likeCount++;
                        }                    
                    }
                    if(ratings.Count > 0)
                    {
                        gameVM.rating = (likeCount / ratings.Count) * 100;
                    }
                }
                return View(gameVM); 
            }
        }

        [HttpGet]
        [Authorize(Roles = "Admin")]
        public ActionResult Edit(int id)
        {
            using(RageQuitContext context = new RageQuitContext())
            {
                Game gameDTO = context.Games.FirstOrDefault(row => row.id == id);
                EditGameViewModel editGameVM = new EditGameViewModel
                {
                    id = gameDTO.id,
                    title = gameDTO.title,
                    description = gameDTO.description,
                    coverArt = gameDTO.coverArt,
                    developer = gameDTO.developer,
                    publisher = gameDTO.publisher,
                    releaseDate = gameDTO.releaseDate
                };
                return View(editGameVM);
            }
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public ActionResult Edit(EditGameViewModel editGameVM)
        {
            if (!ModelState.IsValid)
            {
                return View(editGameVM);
            }
            if (editGameVM == null)
            {
                ModelState.AddModelError("", "Game is required");
                return View();
            }
            if (string.IsNullOrWhiteSpace(editGameVM.title))
            {
                ModelState.AddModelError("", "Title required");
                return View(editGameVM);
            }
            using (RageQuitContext context = new RageQuitContext())
            {
                Game gameDTO = context.Games.FirstOrDefault(row => row.id == editGameVM.id);
                gameDTO.title = editGameVM.title;
                gameDTO.coverArt = editGameVM.coverArt;
                gameDTO.description = editGameVM.description;
                gameDTO.developer = editGameVM.developer;
                gameDTO.publisher = editGameVM.publisher;
                gameDTO.releaseDate = editGameVM.releaseDate;
                context.SaveChanges();
            }
            return RedirectToAction("AddGenres", new { gameId = editGameVM.id });
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public ActionResult Delete(int id)
        {
            using(RageQuitContext context = new RageQuitContext())
            {
                Game gameDTO = context.Games.FirstOrDefault(row => row.id == id);
                gameDTO.isActive = false;
                List<Rating> ratingsListDTO = context.Ratings.Where(row => row.gameId == gameDTO.id).ToList();
                foreach(Rating ratingDTO in ratingsListDTO)
                {
                    ratingDTO.isActive = false;
                }
                context.SaveChanges();

            }
            return RedirectToAction("Index", "Home");
        }
    }
}