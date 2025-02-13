using Microsoft.AspNetCore.Mvc;
using WaterCity.Contract.Repository.Models;
using WaterCity.Contract.Service;
using WaterCity.Core.Constants;
using WaterCity.Core.Exceptions;
using WaterCity.Core.Models;
using WaterCity.Core.Models.NhaMay;

namespace WaterCity.WebApi.Controllers
{
    [ApiController]
    public class NhaMayController : ControllerBase
    {
        private readonly INhaMayService _iNhaMayService;

        public NhaMayController(INhaMayService iNhaMayService)
        {
            _iNhaMayService = iNhaMayService;
        }

        /*[HttpGet]
        [Route(WebApiEndpoint.NhaMay.GetAllNhaMay)]
        public async Task<IActionResult> GetAll()
        {
            var result = await _iNhaMayService.GetAllAsync();
            return Ok(new BaseResponseModel<ICollection<NhaMayEntity>?>(statusCode: StatusCodes.Status200OK, code: ResponseCodeConstants.SUCCESS, data: result));
        }

        [HttpGet]
        [Route(WebApiEndpoint.NhaMay.GetNhaMay)]
        public async Task<IActionResult> GetNhaMayById(string keyId)
        {
            var data = await _iNhaMayService.GetByKeyIdAsync(keyId);
            if (data == null)
            {
                var result = new BaseResponseModel<string>(statusCode: StatusCodes.Status400BadRequest, code: ResponseCodeConstants.NOT_FOUND, message: ReponseMessageConstantsNhaMay.NHA_MAY_NOT_FOUND);
                return BadRequest(result);
            }

            return Ok(new BaseResponseModel<NhaMayEntity?>(statusCode: StatusCodes.Status200OK, code: ResponseCodeConstants.SUCCESS, data: data));
        }*/

        [HttpGet]
        [Route(WebApiEndpoint.NhaMay.GetAllNhaMay)]
        public IActionResult GetAll()
        {
            var result = _iNhaMayService.GetAllAsync();
            return Ok(new BaseResponseModel<ICollection<NhaMayEntity>?>(statusCode: StatusCodes.Status200OK, code: ResponseCodeConstants.SUCCESS, data: result));
        }

        [HttpGet]
        [Route(WebApiEndpoint.NhaMay.GetNhaMay)]
        public IActionResult GetNhaMayById(string keyId)
        {
            var data = _iNhaMayService.GetByKeyIdAsync(keyId);
            if (data == null)
            {
                var result = new BaseResponseModel<string>(statusCode: StatusCodes.Status400BadRequest, code: ResponseCodeConstants.NOT_FOUND, message: ReponseMessageConstantsNhaMay.NHA_MAY_NOT_FOUND);
                return BadRequest(result);
            }

            return Ok(new BaseResponseModel<NhaMayEntity?>(statusCode: StatusCodes.Status200OK, code: ResponseCodeConstants.SUCCESS, data: data));
        }

        [HttpPost]
        [Route(WebApiEndpoint.NhaMay.AddNhaMay)]
        public async Task<IActionResult> CreateNhaMay(NhaMayModel NhaMay)
        {
            try
            {
                var result = await _iNhaMayService.CreateAsync(NhaMay);
                return Ok(new BaseResponseModel<string>(statusCode: StatusCodes.Status201Created, code: ResponseCodeConstants.SUCCESS, data: result));
            }
            catch (Exception e)
            {
                dynamic result;
                if (e is CoreException error)
                {
                    result = new BaseResponseModel<string>(statusCode: error.StatusCode, code: error.Code, message: error.Message);
                    return BadRequest(result);
                }
                result = new BaseResponseModel<string>(statusCode: StatusCodes.Status500InternalServerError, code: ResponseCodeConstants.FAILED, message: e.Message);
                return BadRequest(result);
            }
        }

        [HttpPut]
        [Route(WebApiEndpoint.NhaMay.UpdateNhaMay)]
        public async Task<IActionResult> UpdateNhaMay(string keyId, NhaMayModel request)
        {
            try
            {
                await _iNhaMayService.UpdateAsync(keyId, request);
                return Ok(new BaseResponseModel<string>(statusCode: StatusCodes.Status202Accepted, code: ResponseCodeConstants.SUCCESS, data: ReponseMessageConstantsNhaMay.UPDATE_NHA_MAY_SUCCESS));
            }
            catch (Exception e)
            {
                dynamic result;
                if (e is CoreException error)
                {
                    result = new BaseResponseModel<string>(statusCode: error.StatusCode, code: error.Code, message: error.Message);
                    return BadRequest(result);
                }
                result = new BaseResponseModel<string>(statusCode: StatusCodes.Status500InternalServerError, code: ResponseCodeConstants.FAILED, message: e.Message);
                return BadRequest(result);
            }

        }

        [HttpDelete]
        [Route(WebApiEndpoint.NhaMay.DeleteNhaMay)]
        public async Task<IActionResult> DeleteNhaMay(string keyId)
        {
            try
            {
                await _iNhaMayService.DeleteAsync(keyId, false);
                return Ok(new BaseResponseModel<string>(statusCode: StatusCodes.Status202Accepted, code: ResponseCodeConstants.SUCCESS, data: ReponseMessageConstantsNhaMay.DELETE_NHA_MAY_SUCCESS));
            }
            catch (Exception e)
            {
                dynamic result;
                if (e is CoreException error)
                {
                    result = new BaseResponseModel<string>(statusCode: error.StatusCode, code: error.Code, message: error.Message);
                    return BadRequest(result);
                }
                result = new BaseResponseModel<string>(statusCode: StatusCodes.Status500InternalServerError, code: ResponseCodeConstants.FAILED, message: e.Message);
                return BadRequest(result);
            }
        }
    }
}
