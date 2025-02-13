
using Microsoft.AspNetCore.Mvc;
using WaterCity.Contract.Repository.Models;
using WaterCity.Contract.Service;
using WaterCity.Core.Constants;
using WaterCity.Core.Exceptions;
using WaterCity.Core.Models;
using WaterCity.Core.Models.LyDoHuy;

namespace WaterCity.WebApi.Controllers
{
    [ApiController]
    public class LyDoHuyController : ControllerBase
    {
        private readonly ILyDoHuyService _iLyDoHuyService;

        public LyDoHuyController(ILyDoHuyService iLyDoHuyService)
        {
            _iLyDoHuyService = iLyDoHuyService;
        }

        [HttpGet]
        [Route(WebApiEndpoint.LyDoHuy.GetAllLyDoHuy)]
        public IActionResult GetAll()
        {
            var result = _iLyDoHuyService.GetAllAsync();
            return Ok(new BaseResponseModel<ICollection<LyDoHuyEntity>?>(
                statusCode: StatusCodes.Status200OK,
                code: ResponseCodeConstants.SUCCESS, data: result));
        }

        [HttpGet]
        [Route(WebApiEndpoint.LyDoHuy.GetLyDoHuy)]
        public IActionResult GetLyDoHuyById(string keyId)
        {
            var data = _iLyDoHuyService.GetByKeyIdAsync(keyId);
            if (data == null)
            {
                var result = new BaseResponseModel<string>(
                    statusCode: StatusCodes.Status400BadRequest,
                    code: ResponseCodeConstants.NOT_FOUND,
                    message: ReponseMessageConstantsLyDoHuy.LYDOHUY_NOT_FOUND);
                return BadRequest(result);
            }

            return Ok(new BaseResponseModel<LyDoHuyEntity?>
                    (statusCode: StatusCodes.Status200OK,
                    code: ResponseCodeConstants.SUCCESS, data: data));
        }

        [HttpPost]
        [Route(WebApiEndpoint.LyDoHuy.AddLyDoHuy)]
        public async Task<IActionResult> CreateLyDoHuy(LyDoHuyModel model)
        {
            try
            {
                var result = await _iLyDoHuyService.CreateAsync(model);
                return Ok(new BaseResponseModel<string>(
                    statusCode: StatusCodes.Status201Created,
                    code: ResponseCodeConstants.SUCCESS,
                    data: result));
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
        [Route(WebApiEndpoint.LyDoHuy.UpdateLyDoHuy)]
        public async Task<IActionResult> UpdateLyDoHuy(string keyId, LyDoHuyModel model)
        {
            try
            {
                await _iLyDoHuyService.UpdateAsync(keyId, model);
                return Ok(new BaseResponseModel<string>(
                    statusCode: StatusCodes.Status200OK,
                    code: ResponseCodeConstants.SUCCESS,
                    data: ReponseMessageConstantsLyDoHuy.UPDATE_LYDOHUY_SUCCESS));
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
        [Route(WebApiEndpoint.LyDoHuy.DeleteLyDoHuy)]
        public async Task<IActionResult> DeleteLyDoHuy(string keyId)
        {
            try
            {
                await _iLyDoHuyService.DeleteAsync(keyId, false);
                return Ok(new BaseResponseModel<string>(
                    statusCode: StatusCodes.Status200OK,
                    code: ResponseCodeConstants.SUCCESS,
                    data: ReponseMessageConstantsLyDoHuy.DELETE_LYDOHUY_SUCCESS));
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
