using Microsoft.AspNetCore.Mvc;

namespace ADPTest.WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller[")]
    public abstract class BaseController : ControllerBase
    {
        //protected IActionResult CreateResponse<T>(Results<T> result)
        //{
        //    if (result.IsSuccess)
        //    {
        //        if (result.Value is null) return NoContent();
        //        return Ok(result.Value);
        //    }


        //}

    }
}
