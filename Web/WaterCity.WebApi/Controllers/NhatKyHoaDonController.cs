using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WaterCity.Contract.Repository.Models;
using WaterCity.Contract.Service;
using WaterCity.Core.Constants;
using WaterCity.Core.Exceptions;
using WaterCity.Core.Models.NhatKyHoaDon;
using WaterCity.Core.Models;

namespace WaterCity.WebApi.Controllers
{
    [ApiController]
    public class NhatKyHoaDonController : ControllerBase
    {
        private readonly INhatKyHoaDonService _iNhatKyHoaDonService;


        public NhatKyHoaDonController(INhatKyHoaDonService iNhatKyHoaDonService)
        {
            _iNhatKyHoaDonService = iNhatKyHoaDonService;
        }

        /*[HttpGet]
        [Route(WebApiEndpoint.NhatKyHoaDon.GetAllNhatKyHoaDon)]
        public async Task<IActionResult> GetAll()
        {
            var result = await _iNhatKyHoaDonService.GetAllAsync();
            return Ok(new BaseResponseModel<ICollection<NhatKyHoaDonEntity>?>(statusCode: StatusCodes.Status200OK, code: ResponseCodeConstants.SUCCESS, data: result));
        }

        [HttpGet]
        [Route(WebApiEndpoint.NhatKyHoaDon.GetNhatKyHoaDon)]
        public async Task<IActionResult> GetNhatKyHoaDonById(string keyId)
        {
            var data = await _iNhatKyHoaDonService.GetByKeyIdAsync(keyId);
            if (data == null)
            {
                var result = new BaseResponseModel<string>(statusCode: StatusCodes.Status400BadRequest, code: ResponseCodeConstants.NOT_FOUND, message: ReponseMessageConstantsNhatKyHoaDon.NHAT_KY_HOA_DON_NOT_FOUND);
                return BadRequest(result);
            }

            return Ok(new BaseResponseModel<NhatKyHoaDonEntity?>(statusCode: StatusCodes.Status200OK, code: ResponseCodeConstants.SUCCESS, data: data));
        }*/

        [HttpGet]
        [Route(WebApiEndpoint.NhatKyHoaDon.GetAllNhatKyHoaDon)]
        public IActionResult GetAll()
        {
            var result = _iNhatKyHoaDonService.GetAllAsync();
            return Ok(new BaseResponseModel<ICollection<NhatKyHoaDonEntity>?>(statusCode: StatusCodes.Status200OK, code: ResponseCodeConstants.SUCCESS, data: result));
        }

        [HttpGet]
        [Route(WebApiEndpoint.NhatKyHoaDon.GetNhatKyHoaDon)]
        public IActionResult GetNhatKyHoaDonById(string keyId)
        {
            var data = _iNhatKyHoaDonService.GetByKeyIdAsync(keyId);
            if (data == null)
            {
                var result = new BaseResponseModel<string>(statusCode: StatusCodes.Status400BadRequest, code: ResponseCodeConstants.NOT_FOUND, message: ReponseMessageConstantsNhatKyHoaDon.NHAT_KY_HOA_DON_NOT_FOUND);
                return BadRequest(result);
            }

            return Ok(new BaseResponseModel<NhatKyHoaDonEntity?>(statusCode: StatusCodes.Status200OK, code: ResponseCodeConstants.SUCCESS, data: data));
        }

        [HttpPost]
        [Route(WebApiEndpoint.NhatKyHoaDon.AddNhatKyHoaDon)]
        public async Task<IActionResult> CreateNhatKyHoaDon(NhatKyHoaDonModel NhatKyHoaDon)
        {
            try
            {
                var result = await _iNhatKyHoaDonService.CreateAsync(NhatKyHoaDon);
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
        [Route(WebApiEndpoint.NhatKyHoaDon.UpdateNhatKyHoaDon)]
        public async Task<IActionResult> UpdateNhatKyHoaDon(string keyId, NhatKyHoaDonModel request)
        {
            try
            {
                await _iNhatKyHoaDonService.UpdateAsync(keyId, request);
                return Ok(new BaseResponseModel<string>(statusCode: StatusCodes.Status202Accepted, code: ResponseCodeConstants.SUCCESS, data: ReponseMessageConstantsNhatKyHoaDon.UPDATE_NHAT_KY_HOA_DON_SUCCESS));
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
        [Route(WebApiEndpoint.NhatKyHoaDon.DeleteNhatKyHoaDon)]
        public async Task<IActionResult> DeleteNhatKyHoaDon(string keyId)
        {
            try
            {
                await _iNhatKyHoaDonService.DeleteAsync(keyId, false);
                return Ok(new BaseResponseModel<string>(statusCode: StatusCodes.Status202Accepted, code: ResponseCodeConstants.SUCCESS, data: ReponseMessageConstantsNhatKyHoaDon.DELETE_NHAT_KY_HOA_DON_SUCCESS));
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
