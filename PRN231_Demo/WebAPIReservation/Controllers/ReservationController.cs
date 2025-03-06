using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Xml.Linq;
using WebAPIReservation.Models;
using WebAPIReservation.Repository;

namespace WebAPIReservation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReservationController : ControllerBase
    {
        private IRepository repository;
        private IWebHostEnvironment environment;
        public ReservationController(IRepository repository, IWebHostEnvironment environment)
        {
            this.repository = repository;
            this.environment = environment;
        }

        [HttpGet]
        public IEnumerable<Reservation> Get() => repository.Reservations;

        [HttpGet("{id}")]
        public ActionResult<Reservation> Get(int id)
        {
            if(id == 0)
            {
                return BadRequest("Value must be passed in the request body");
            }
            return Ok(repository[id]);
        }

        [HttpPost]
        public Reservation Post([FromBody]Reservation reservation) =>
            repository.AddReservation(new Reservation
            {
                Name = reservation.Name,
                StartLocation = reservation.StartLocation,
                EndLocation = reservation.EndLocation
            });

        [HttpPut]
        public Reservation Put([FromForm]Reservation reservation) => repository.UpdateReservation(reservation);

        [HttpDelete("{id}")]
        public void Delete(int id) => repository.DeleteReservation(id);

        [HttpPost("Postxml")]
        [Consumes("application/xml")]
        public Reservation PostXml([FromBody] XElement res)
        {
            return repository.AddReservation(new Reservation
            {
                Name = res.Element("Name").Value,
                StartLocation = res.Element("StartLocation").Value,
                EndLocation = res.Element("EndLocation").Value
            });
        }

        [HttpGet("ShowReservation.{format}"), FormatFilter]
        public IEnumerable<Reservation> ShowReservation() => repository.Reservations;


    }
}
