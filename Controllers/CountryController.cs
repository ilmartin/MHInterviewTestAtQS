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
        /// <summary>
        /// Get a list of all countries data based on the list in ISO 3166
        /// </summary>
        /// <param name="count"></param>
        /// <returns></returns>
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
        /// <summary>
        /// Get a specific country data
        /// </summary>
        /// <param name="ISOname">Provide the two letter ISO region name of the country</param>
        /// <returns></returns>
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
