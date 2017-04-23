using RageQuit.Models.Data;
using RageQuit.Models.ViewModels.Home;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RageQuit.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            HomePageViewModel homePageVM = new HomePageViewModel()
            {
                upcomingList = new List<HomePageGameViewModel>(),
                ratedList = new List<HomePageGameViewModel>(),
                popularList = new List<HomePageGameViewModel>()
            };
            List<HomePageGameViewModel> listHomePageGameVM = new List<HomePageGameViewModel>();
            using(RageQuitContext context = new RageQuitContext())
            {
                List<Game> games = context.Games.ToList();
                foreach(Game gameDTO in games)
                {
                    if(gameDTO.isActive)
                    {
                        HomePageGameViewModel homePageGameVM = new HomePageGameViewModel()
                        {
                            id = gameDTO.id,
                            title = gameDTO.title,
                            rating = 0,
                            releaseDate = gameDTO.releaseDate
                        };
                        listHomePageGameVM.Add(homePageGameVM);
                    }
                }
                foreach (HomePageGameViewModel homePageGameVM in listHomePageGameVM)
                {
                    if (DateTime.Compare(DateTime.Now, homePageGameVM.releaseDate) >= 0)
                    {
                        List<Rating> listRating = context.Ratings.Where(row => row.gameId == homePageGameVM.id && row.isActive).ToList();
                        homePageGameVM.ratingsCount = listRating.Count;
                        int likeCount = 0;
                        foreach (Rating rating in listRating)
                        {
                            if (rating.isLiked)
                            {
                                likeCount++;
                            }
                        }
                        if (likeCount != 0)
                        {
                            homePageGameVM.rating = (likeCount / homePageGameVM.ratingsCount) * 100;
                        }
                        homePageVM.ratedList.Add(homePageGameVM);
                        homePageVM.popularList.Add(homePageGameVM);
                    }
                    else
                    {
                        homePageVM.upcomingList.Add(homePageGameVM);
                    }
                }
            }
            return View(homePageVM);
        }
    }
}