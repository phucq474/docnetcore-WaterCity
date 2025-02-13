using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WaterCity.Contract.Repository.Models;
using WaterCity.Contract.Service;
using WaterCity.Core.Constants;
using WaterCity.Core.Exceptions;
using WaterCity.Core.Models.LichSuSMS;
using WaterCity.Core.Models;

namespace WaterCity.WebApi.Controllers
{
    [ApiController]
    public class LichSuSMSController : ControllerBase
    {
        private readonly ILichSuSMSService _iLichSuSMSService;

        public LichSuSMSController(ILichSuSMSService iLichSuSMSService)
        {
            _iLichSuSMSService = iLichSuSMSService;
        }

        /*[HttpGet]
        [Route(WebApiEndpoint.LichSuSMS.GetAllLichSuSMS)]
        public async Task<IActionResult> GetAll()
        {
            var result = await _iLichSuSMSService.GetAllAsync();
            return Ok(new BaseResponseModel<ICollection<LichSuSMSEntity>?>(statusCode: StatusCodes.Status200OK, code: ResponseCodeConstants.SUCCESS, data: result));
        }

        [HttpGet]
        [Route(WebApiEndpoint.LichSuSMS.GetLichSuSMS)]
        public async Task<IActionResult> GetLichSuSMSById(string keyId)
        {
            var data = await _iLichSuSMSService.GetByKeyIdAsync(keyId);
            if (data == null)
            {
                var result = new BaseResponseModel<string>(statusCode: StatusCodes.Status400BadRequest, code: ResponseCodeConstants.NOT_FOUND, message: ReponseMessageConstantsLichSuSMS.LICH_SU_SMS_NOT_FOUND);
                return BadRequest(result);
            }

            return Ok(new BaseResponseModel<LichSuSMSEntity?>(statusCode: StatusCodes.Status200OK, code: ResponseCodeConstants.SUCCESS, data: data));
        }*/

        [HttpGet]
        [Route(WebApiEndpoint.LichSuSMS.GetAllLichSuSMS)]
        public IActionResult GetAll()
        {
            var result = _iLichSuSMSService.GetAllAsync();
            return Ok(new BaseResponseModel<ICollection<LichSuSMSEntity>?>(statusCode: StatusCodes.Status200OK, code: ResponseCodeConstants.SUCCESS, data: result));
        }

        [HttpGet]
        [Route(WebApiEndpoint.LichSuSMS.GetLichSuSMS)]
        public IActionResult GetLichSuSMSById(string keyId)
        {
            var data = _iLichSuSMSService.GetByKeyIdAsync(keyId);
            if (data == null)
            {
                var result = new BaseResponseModel<string>(statusCode: StatusCodes.Status400BadRequest, code: ResponseCodeConstants.NOT_FOUND, message: ReponseMessageConstantsLichSuSMS.LICH_SU_SMS_NOT_FOUND);
                return BadRequest(result);
            }

            return Ok(new BaseResponseModel<LichSuSMSEntity?>(statusCode: StatusCodes.Status200OK, code: ResponseCodeConstants.SUCCESS, data: data));
        }

        [HttpPost]
        [Route(WebApiEndpoint.LichSuSMS.AddLichSuSMS)]
        public async Task<IActionResult> CreateLichSuSMS(LichSuSMSModel LichSuSMS)
        {
            try
            {
                var result = await _iLichSuSMSService.CreateAsync(LichSuSMS);
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
        [Route(WebApiEndpoint.LichSuSMS.UpdateLichSuSMS)]
        public async Task<IActionResult> UpdateLichSuSMS(string keyId, LichSuSMSModel request)
        {
            try
            {
                await _iLichSuSMSService.UpdateAsync(keyId, request);
                return Ok(new BaseResponseModel<string>(statusCode: StatusCodes.Status202Accepted, code: ResponseCodeConstants.SUCCESS, data: ReponseMessageConstantsLichSuSMS.UPDATE_LICH_SU_SMS_SUCCESS));
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
        [Route(WebApiEndpoint.LichSuSMS.DeleteLichSuSMS)]
        public async Task<IActionResult> DeleteLichSuSMS(string keyId)
        {
            try
            {
                await _iLichSuSMSService.DeleteAsync(keyId, false);
                return Ok(new BaseResponseModel<string>(statusCode: StatusCodes.Status202Accepted, code: ResponseCodeConstants.SUCCESS, data: ReponseMessageConstantsLichSuSMS.DELETE_LICH_SU_SMS_SUCCESS));
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
