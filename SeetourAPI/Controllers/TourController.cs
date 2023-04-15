using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using SeetourAPI.BL.TourManger;
using SeetourAPI.Data.Models;

namespace SeetourAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TourController : ControllerBase
    {
        public ITourManger ITourManger { get; }
        public TourController(ITourManger ITourManger)
        {
            this.ITourManger = ITourManger;
        }
        [HttpPost]
        public ActionResult CreateTour(Tour tour)
        {
              ITourManger.AddTour(tour);
                return Created("", tour);    
        }
        [HttpPut]
        public ActionResult EditTour(int id,Tour tour)
        {
            if(tour.Id!=id)
            {
                return BadRequest();
            }
            else
            {
            ITourManger.EditTour(id, tour);
            return Ok();
            }
        }
        [HttpDelete]
        public ActionResult DeleteTour(int id)
        {
            ITourManger.DeleteTour(id);
            return  NoContent();
        }
        [HttpGet]
        [Route("GetById")]
        public ActionResult GetById(int id)
        {
          var t=  ITourManger.GetTourById(id);
            if (t == null)
            {
                return NotFound();
            }
            return Ok(t);
        }
        [HttpGet]
        [Route("GetAll")]
        public ActionResult GetAll()
        {
            var tours = ITourManger.GetAll();
            if(tours == null)
            {
                return NotFound();
            }
            return Ok(ITourManger.GetAll());
        }
        [HttpGet]
        [Route("TourDetails")]
        public ActionResult Details(int id)
        {
            var tour = ITourManger.GetTourById(id);
            if (tour?.Id == id)
            {
                return Ok( ITourManger.Details(id));

            }
            return NotFound();
        }
    }
}
