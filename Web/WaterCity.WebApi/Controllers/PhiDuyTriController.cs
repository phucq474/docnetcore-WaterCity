using Microsoft.AspNetCore.Mvc;
using WaterCity.Contract.Repository.Models;
using WaterCity.Contract.Service;
using WaterCity.Core.Constants;
using WaterCity.Core.Exceptions;
using WaterCity.Core.Models;
using WaterCity.Core.Models.PhiDuyTri;

namespace WaterCity.WebApi.Controllers
{
    [ApiController]
    public class PhiDuyTriController : ControllerBase
    {
        private readonly IPhiDuyTriService _iPhiDuyTriService;

        public PhiDuyTriController(IPhiDuyTriService iPhiDuyTriService)
        {
            _iPhiDuyTriService = iPhiDuyTriService;
        }

        [HttpGet]
        [Route(WebApiEndpoint.PhiDuyTri.GetAllPhiDuyTri)]
        public IActionResult GetAll()
        {
            var result = _iPhiDuyTriService.GetAllAsync();
            return Ok(new BaseResponseModel<ICollection<PhiDuyTriEntity>?>(
                statusCode: StatusCodes.Status200OK,
                code: ResponseCodeConstants.SUCCESS, data: result));
        }

        [HttpGet]
        [Route(WebApiEndpoint.PhiDuyTri.GetPhiDuyTri)]
        public IActionResult GetPhiDuyTriById(string keyId)
        {
            var data = _iPhiDuyTriService.GetByKeyIdAsync(keyId);
            if (data == null)
            {
                var result = new BaseResponseModel<string>(
                    statusCode: StatusCodes.Status400BadRequest,
                    code: ResponseCodeConstants.NOT_FOUND,
                    message: ReponseMessageConstantsPhiDuyTri.PHI_DUY_TRI_NOT_FOUND);
                return BadRequest(result);
            }

            return Ok(new BaseResponseModel<PhiDuyTriEntity?>
                    (statusCode: StatusCodes.Status200OK,
                    code: ResponseCodeConstants.SUCCESS, data: data));
        }

        [HttpPost]
        [Route(WebApiEndpoint.PhiDuyTri.AddPhiDuyTri)]
        public async Task<IActionResult> CreatePhiDuyTri(PhiDuyTriModel model)
        {
            try
            {
                var result = await _iPhiDuyTriService.CreateAsync(model);
                return Ok(new BaseResponseModel<string>(
                    statusCode: StatusCodes.Status201Created,
                    code: ResponseCodeConstants.SUCCESS, data: result));
            }
            catch (Exception e)
            {
                dynamic result;
                if (e is CoreException error)
                {
                    result = new BaseResponseModel<string>(
                        statusCode: error.StatusCode,
                        code: error.Code,
                        message: error.Message);
                    return BadRequest(result);
                }
                result = new BaseResponseModel<string>(
                    statusCode: StatusCodes.Status500InternalServerError,
                    code: ResponseCodeConstants.FAILED,
                    message: e.Message);
                return BadRequest(result);
            }
        }

        [HttpPut]
        [Route(WebApiEndpoint.PhiDuyTri.UpdatePhiDuyTri)]
        public async Task<IActionResult> UpdatePhiDuyTri(string keyId, PhiDuyTriModel request)
        {
            try
            {
                await _iPhiDuyTriService.UpdateAsync(keyId, request);
                return Ok(new BaseResponseModel<string>(
                    statusCode: StatusCodes.Status200OK,
                    code: ResponseCodeConstants.SUCCESS,
                    data: "Update success"));
            }
            catch (Exception e)
            {
                dynamic result;
                if (e is CoreException error)
                {
                    result = new BaseResponseModel<string>(
                        statusCode: error.StatusCode,
                        code: error.Code,
                        message: error.Message);
                    return BadRequest(result);
                }
                result = new BaseResponseModel<string>(
                    statusCode: StatusCodes.Status500InternalServerError,
                    code: ResponseCodeConstants.FAILED,
                    message: e.Message);
                return BadRequest(result);
            }

        }

        [HttpDelete]
        [Route(WebApiEndpoint.PhiDuyTri.DeletePhiDuyTri)]
        public async Task<IActionResult> DeletePhiDuyTri(string keyId)
        {
            try
            {
                await _iPhiDuyTriService.DeleteAsync(keyId, false);
                return Ok(new BaseResponseModel<string>(
                    statusCode: StatusCodes.Status200OK,
                    code: ResponseCodeConstants.SUCCESS,
                    data: "Delete success"));
            }
            catch (Exception e)
            {
                dynamic result;
                if (e is CoreException error)
                {
                    result = new BaseResponseModel<string>(
                        statusCode: error.StatusCode,
                        code: error.Code,
                        message: error.Message);
                    return BadRequest(result);
                }
                result = new BaseResponseModel<string>(
                    statusCode: StatusCodes.Status500InternalServerError,
                    code: ResponseCodeConstants.FAILED,
                    message: e.Message);
                return BadRequest(result);
            }
        }
    }
}
