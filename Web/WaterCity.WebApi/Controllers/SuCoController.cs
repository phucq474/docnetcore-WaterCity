using Microsoft.AspNetCore.Mvc;
using WaterCity.Contract.Repository.Models;
using WaterCity.Contract.Service;
using WaterCity.Core.Constants;
using WaterCity.Core.Exceptions;
using WaterCity.Core.Models;
using WaterCity.Core.Models.SuCo;

namespace WaterCity.WebApi.Controllers
{
    [ApiController]
    public class SuCoController : ControllerBase
    {
        private readonly ISuCoService _iSuCoService;

        public SuCoController(ISuCoService iSuCoService)
        {
            _iSuCoService = iSuCoService;
        }

        /*[HttpGet]
        [Route(WebApiEndpoint.SuCo.GetAllSuCo)]
        public async Task<IActionResult> GetAll()
        {
            var result = await _iSuCoService.GetAllAsync();
            return Ok(new BaseResponseModel<ICollection<SuCoEntity>?>(
                statusCode: StatusCodes.Status200OK, 
                code: ResponseCodeConstants.SUCCESS, data: result));
        }

        [HttpGet]
        [Route(WebApiEndpoint.SuCo.GetSuCo)]
        public async Task<IActionResult> GetSuCoById(string keyId)
        {
            var data = await _iSuCoService.GetByKeyIdAsync(keyId);
            if (data == null)
            {
                var result = new BaseResponseModel<string>(
                    statusCode: StatusCodes.Status400BadRequest, 
                    code: ResponseCodeConstants.NOT_FOUND, 
                    message: ReponseMessageConstantsSuCo.SU_CO_NOT_FOUND);
                return BadRequest(result);
            }

            return Ok(new BaseResponseModel<SuCoEntity?>
                    (statusCode: StatusCodes.Status200OK, 
                    code: ResponseCodeConstants.SUCCESS, data: data));
        }*/

        [HttpGet]
        [Route(WebApiEndpoint.SuCo.GetAllSuCo)]
        public IActionResult GetAll()
        {
            var result = _iSuCoService.GetAllAsync();
            return Ok(new BaseResponseModel<ICollection<SuCoEntity>?>(
                statusCode: StatusCodes.Status200OK,
                code: ResponseCodeConstants.SUCCESS, data: result));
        }

        [HttpGet]
        [Route(WebApiEndpoint.SuCo.GetSuCo)]
        public IActionResult GetSuCoById(string keyId)
        {
            var data = _iSuCoService.GetByKeyIdAsync(keyId);
            if (data == null)
            {
                var result = new BaseResponseModel<string>(
                    statusCode: StatusCodes.Status400BadRequest,
                    code: ResponseCodeConstants.NOT_FOUND,
                    message: ReponseMessageConstantsSuCo.SU_CO_NOT_FOUND);
                return BadRequest(result);
            }

            return Ok(new BaseResponseModel<SuCoEntity?>
                    (statusCode: StatusCodes.Status200OK,
                    code: ResponseCodeConstants.SUCCESS, data: data));
        }

        [HttpPost]
        [Route(WebApiEndpoint.SuCo.AddSuCo)]
        public async Task<IActionResult> CreateSuCo(SuCoModel model)
        {
            try
            {
                var result = await _iSuCoService.CreateAsync(model);
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
        [Route(WebApiEndpoint.SuCo.UpdateSuCo)]
        public async Task<IActionResult> UpdateSuCo(string keyId, SuCoModel model)
        {
            try
            {
                await _iSuCoService.UpdateAsync(keyId, model);
                return Ok(new BaseResponseModel<string>(
                    statusCode: StatusCodes.Status200OK,
                    code: ResponseCodeConstants.SUCCESS,
                    data: ReponseMessageConstantsSuCo.UPDATE_SU_CO_SUCCESS));
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
        [Route(WebApiEndpoint.SuCo.DeleteSuCo)]
        public async Task<IActionResult> DeleteSuCo(string keyId)
        {
            try
            {
                await _iSuCoService.DeleteAsync(keyId, false);
                return Ok(new BaseResponseModel<string>(
                    statusCode: StatusCodes.Status200OK,
                    code: ResponseCodeConstants.SUCCESS,
                    data: ReponseMessageConstantsSuCo.DELETE_SU_CO_SUCCESS));
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
