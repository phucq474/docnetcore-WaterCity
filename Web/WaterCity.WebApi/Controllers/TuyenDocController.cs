using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WaterCity.Contract.Repository.Models;
using WaterCity.Contract.Service;
using WaterCity.Core.Constants;
using WaterCity.Core.Exceptions;
using WaterCity.Core.Models.TuyenDoc;
using WaterCity.Core.Models;

namespace WaterCity.WebApi.Controllers
{
    [ApiController]
    public class TuyenDocController : ControllerBase
    {
        private readonly ITuyenDocService _iTuyenDocService;

        public TuyenDocController(ITuyenDocService iTuyenDocService)
        {
            _iTuyenDocService = iTuyenDocService;
        }

        /*[HttpGet]
        [Route(WebApiEndpoint.TuyenDoc.GetAllTuyenDoc)]
        public async Task<IActionResult> GetAll()
        {
            var result = await _iTuyenDocService.GetAllAsync();
            return Ok(new BaseResponseModel<ICollection<TuyenDocEntity>?>(statusCode: StatusCodes.Status200OK, code: ResponseCodeConstants.SUCCESS, data: result));
        }

        [HttpGet]
        [Route(WebApiEndpoint.TuyenDoc.GetTuyenDoc)]
        public async Task<IActionResult> GetTuyenDocById(string keyId)
        {
            var data = await _iTuyenDocService.GetByKeyIdAsync(keyId);
            if (data == null)
            {
                var result = new BaseResponseModel<string>(statusCode: StatusCodes.Status400BadRequest, code: ResponseCodeConstants.NOT_FOUND, message: ReponseMessageConstantsTuyenDoc.TUYEN_DOC_NOT_FOUND);
                return BadRequest(result);
            }

            return Ok(new BaseResponseModel<TuyenDocEntity?>(statusCode: StatusCodes.Status200OK, code: ResponseCodeConstants.SUCCESS, data: data));
        }*/

        [HttpGet]
        [Route(WebApiEndpoint.TuyenDoc.GetAllTuyenDoc)]
        public IActionResult GetAll()
        {
            var result = _iTuyenDocService.GetAllAsync();
            return Ok(new BaseResponseModel<ICollection<TuyenDocEntity>?>(statusCode: StatusCodes.Status200OK, code: ResponseCodeConstants.SUCCESS, data: result));
        }

        [HttpGet]
        [Route(WebApiEndpoint.TuyenDoc.GetTuyenDoc)]
        public IActionResult GetTuyenDocById(string keyId)
        {
            var data = _iTuyenDocService.GetByKeyIdAsync(keyId);
            if (data == null)
            {
                var result = new BaseResponseModel<string>(statusCode: StatusCodes.Status400BadRequest, code: ResponseCodeConstants.NOT_FOUND, message: ReponseMessageConstantsTuyenDoc.TUYEN_DOC_NOT_FOUND);
                return BadRequest(result);
            }

            return Ok(new BaseResponseModel<TuyenDocEntity?>(statusCode: StatusCodes.Status200OK, code: ResponseCodeConstants.SUCCESS, data: data));
        }

        [HttpPost]
        [Route(WebApiEndpoint.TuyenDoc.AddTuyenDoc)]
        public async Task<IActionResult> CreateTuyenDoc(TuyenDocModel TuyenDoc)
        {
            try
            {
                var result = await _iTuyenDocService.CreateAsync(TuyenDoc);
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
        [Route(WebApiEndpoint.TuyenDoc.UpdateTuyenDoc)]
        public async Task<IActionResult> UpdateTuyenDoc(string keyId, TuyenDocModel request)
        {
            try
            {
                await _iTuyenDocService.UpdateAsync(keyId, request);
                return Ok(new BaseResponseModel<string>(statusCode: StatusCodes.Status202Accepted, code: ResponseCodeConstants.SUCCESS, data: ReponseMessageConstantsTuyenDoc.TUYEN_DOC_NOT_FOUND));
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
        [Route(WebApiEndpoint.TuyenDoc.DeleteTuyenDoc)]
        public async Task<IActionResult> DeleteTuyenDoc(string keyId)
        {
            try
            {
                await _iTuyenDocService.DeleteAsync(keyId, false);
                return Ok(new BaseResponseModel<string>(statusCode: StatusCodes.Status202Accepted, code: ResponseCodeConstants.SUCCESS, data: ReponseMessageConstantsTuyenDoc.DELETE_TUYEN_DOC_SUCCESS));
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
