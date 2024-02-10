using MartinHuiLoanApplicationApi.Const;
using Microsoft.AspNetCore.Mvc;
using System.Globalization;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MartinHuiLoanApplicationApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CountryController : ControllerBase
    {
        // GET: api/<CountryController>
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get([FromQuery] bool count)
        {
            if (count)
            {
                return Ok(Constants.Countries.Count());
            }
            return Ok(Constants.Countries);
        }

        // GET api/<CountryController>/de
        [HttpGet("{id}")]
        public ActionResult<RegionInfo> Get(string ISOname)
        {
            var country = Constants.Countries.FirstOrDefault(x => x.TwoLetterISORegionName.Equals(ISOname,StringComparison.OrdinalIgnoreCase));
            if (country == null)
            {
                return NotFound();
            }
            return country;
        }

    }
}
