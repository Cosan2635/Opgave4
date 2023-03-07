using Microsoft.AspNetCore.Mvc;
using Opgave1;
using Opgave4.Repository;

namespace Opgave4.Controllers
{
    
    [Route("api/[controller]")]
    //URL:api/cars
    [ApiController]
    public class CarController : ControllerBase
    {
        private CarRepository _repository;
        public CarController(CarRepository repository)
        {
            _repository = repository;
        }

        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [HttpGet]

        public ActionResult<IEnumerable<Car>> GetAll()
        {
            return _repository.GetAll();
        }
            



        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpGet("{id}")]
        public ActionResult<Car> Get(int id)
        {
            Car? foundCar = _repository.GetById(id);
            if (foundCar == null)
            {
                return NotFound();
            }
            return Ok(foundCar);
        }

        // POST api/<ValuesController>
        [HttpPost]
        public ActionResult<Car> Post([FromBody] Car newCar)
        {
            try
            {
                Car? CreateCar = _repository.Add(newCar);
                return Created($"api/pokemons/{CreateCar.Id}", CreateCar);
            }
            catch (ArgumentNullException x)
            {
                return BadRequest(x.Message);
            }
            catch (ArgumentOutOfRangeException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
        }


        // PUT api/<ValuesController>/5
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpPut("{id}")]
        public ActionResult<Car> Put(int id, [FromBody] Car updates)
        {
            try
            {
                Car? updateCar = _repository.Update(id, updates);
                if (updateCar == null)
                {
                    return NotFound();
                }
                return Ok(updateCar);
            }
            catch (ArgumentNullException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (ArgumentOutOfRangeException
            ex)
            {
                return BadRequest(ex.Message);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
        }


        // DELETE api/<ValuesController>/5
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            Car? deleteCar = _repository.Delete(id);
            if (deleteCar == null)
            {
                return NotFound();
            }
            return NoContent();
        }

    }
}