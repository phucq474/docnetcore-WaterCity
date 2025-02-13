using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WaterCity.Contract.Repository.Models;
using WaterCity.Contract.Service;
using WaterCity.Core.Constants;
using WaterCity.Core.Exceptions;
using WaterCity.Core.Models.MauTinSMS;
using WaterCity.Core.Models;

namespace WaterCity.WebApi.Controllers
{
    [ApiController]
    public class MauTinSMSController : ControllerBase
    {
        private readonly IMauTinSMSService _iMauTinSMSService;

        public MauTinSMSController(IMauTinSMSService iMauTinSMSService)
        {
            _iMauTinSMSService = iMauTinSMSService;
        }

        /*[HttpGet]
        [Route(WebApiEndpoint.MauTinSMS.GetAllMauTinSMS)]
        public async Task<IActionResult> GetAll()
        {
            var result = await _iMauTinSMSService.GetAllAsync();
            return Ok(new BaseResponseModel<ICollection<MauTinSMSEntity>?>(statusCode: StatusCodes.Status200OK, code: ResponseCodeConstants.SUCCESS, data: result));
        }

        [HttpGet]
        [Route(WebApiEndpoint.MauTinSMS.GetMauTinSMS)]
        public async Task<IActionResult> GetMauTinSMSById(string keyId)
        {
            var data = await _iMauTinSMSService.GetByKeyIdAsync(keyId);
            if (data == null)
            {
                var result = new BaseResponseModel<string>(statusCode: StatusCodes.Status400BadRequest, code: ResponseCodeConstants.NOT_FOUND, message: ReponseMessageConstantsMauTinSMS.MAU_TIN_SMS_NOT_FOUND);
                return BadRequest(result);
            }

            return Ok(new BaseResponseModel<MauTinSMSEntity?>(statusCode: StatusCodes.Status200OK, code: ResponseCodeConstants.SUCCESS, data: data));
        }*/

        [HttpGet]
        [Route(WebApiEndpoint.MauTinSMS.GetAllMauTinSMS)]
        public IActionResult GetAll()
        {
            var result = _iMauTinSMSService.GetAllAsync();
            return Ok(new BaseResponseModel<ICollection<MauTinSMSEntity>?>(statusCode: StatusCodes.Status200OK, code: ResponseCodeConstants.SUCCESS, data: result));
        }

        [HttpGet]
        [Route(WebApiEndpoint.MauTinSMS.GetMauTinSMS)]
        public IActionResult GetMauTinSMSById(string keyId)
        {
            var data = _iMauTinSMSService.GetByKeyIdAsync(keyId);
            if (data == null)
            {
                var result = new BaseResponseModel<string>(statusCode: StatusCodes.Status400BadRequest, code: ResponseCodeConstants.NOT_FOUND, message: ReponseMessageConstantsMauTinSMS.MAU_TIN_SMS_NOT_FOUND);
                return BadRequest(result);
            }

            return Ok(new BaseResponseModel<MauTinSMSEntity?>(statusCode: StatusCodes.Status200OK, code: ResponseCodeConstants.SUCCESS, data: data));
        }

        [HttpPost]
        [Route(WebApiEndpoint.MauTinSMS.AddMauTinSMS)]
        public async Task<IActionResult> CreateMauTinSMS(MauTinSMSModel MauTinSMS)
        {
            try
            {
                var result = await _iMauTinSMSService.CreateAsync(MauTinSMS);
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
        [Route(WebApiEndpoint.MauTinSMS.UpdateMauTinSMS)]
        public async Task<IActionResult> UpdateMauTinSMS(string keyId, MauTinSMSModel request)
        {
            try
            {
                await _iMauTinSMSService.UpdateAsync(keyId, request);
                return Ok(new BaseResponseModel<string>(statusCode: StatusCodes.Status202Accepted, code: ResponseCodeConstants.SUCCESS, data: ReponseMessageConstantsMauTinSMS.UPDATE_MAU_TIN_SMS_SUCCESS));
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
        [Route(WebApiEndpoint.MauTinSMS.DeleteMauTinSMS)]
        public async Task<IActionResult> DeleteMauTinSMS(string keyId)
        {
            try
            {
                await _iMauTinSMSService.DeleteAsync(keyId, false);
                return Ok(new BaseResponseModel<string>(statusCode: StatusCodes.Status202Accepted, code: ResponseCodeConstants.SUCCESS, data: ReponseMessageConstantsMauTinSMS.DELETE_MAU_TIN_SMS_SUCCESS));
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
