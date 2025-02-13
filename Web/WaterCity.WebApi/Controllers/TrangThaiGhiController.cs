using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WaterCity.Contract.Repository.Models;
using WaterCity.Contract.Service;
using WaterCity.Core.Constants;
using WaterCity.Core.Exceptions;
using WaterCity.Core.Models.TrangThaiGhi;
using WaterCity.Core.Models;
using WaterCity.Service;

namespace WaterCity.WebApi.Controllers
{
    [ApiController]
    public class TrangThaiGhiController : ControllerBase
    {
        private readonly ITrangThaiGhiService _iTrangThaiGhiService;

        public TrangThaiGhiController(ITrangThaiGhiService iTrangThaiGhiService)
        {
            _iTrangThaiGhiService = iTrangThaiGhiService;
        }

        /*[HttpGet]
        [Route(WebApiEndpoint.TrangThaiGhi.GetAllTrangThaiGhi)]
        public async Task<IActionResult> GetAll()
        {
            var result = await _iTrangThaiGhiService.GetAllAsync();
            return Ok(new BaseResponseModel<ICollection<TrangThaiGhiEntity>?>(statusCode: StatusCodes.Status200OK, code: ResponseCodeConstants.SUCCESS, data: result));
        }

        [HttpGet]
        [Route(WebApiEndpoint.TrangThaiGhi.GetTrangThaiGhi)]
        public async Task<IActionResult> GetTrangThaiGhiById(string keyId)
        {
            var data = await _iTrangThaiGhiService.GetByKeyIdAsync(keyId);
            if (data == null)
            {
                var result = new BaseResponseModel<string>(statusCode: StatusCodes.Status400BadRequest, code: ResponseCodeConstants.NOT_FOUND, message: ReponseMessageConstantsTrangThaiGhi.TRANG_THAI_GHI_NOT_FOUND);
                return BadRequest(result);
            }

            return Ok(new BaseResponseModel<TrangThaiGhiEntity?>(statusCode: StatusCodes.Status200OK, code: ResponseCodeConstants.SUCCESS, data: data));
        }*/

        [HttpGet]
        [Route(WebApiEndpoint.TrangThaiGhi.GetAllTrangThaiGhi)]
        public IActionResult GetAll()
        {
            var result = _iTrangThaiGhiService.GetAllAsync();
            return Ok(new BaseResponseModel<ICollection<TrangThaiGhiEntity>?>(statusCode: StatusCodes.Status200OK, code: ResponseCodeConstants.SUCCESS, data: result));
        }

        [HttpGet]
        [Route(WebApiEndpoint.TrangThaiGhi.GetTrangThaiGhi)]
        public IActionResult GetTrangThaiGhiById(string keyId)
        {
            var data = _iTrangThaiGhiService.GetByKeyIdAsync(keyId);
            if (data == null)
            {
                var result = new BaseResponseModel<string>(statusCode: StatusCodes.Status400BadRequest, code: ResponseCodeConstants.NOT_FOUND, message: ReponseMessageConstantsTrangThaiGhi.TRANG_THAI_GHI_NOT_FOUND);
                return BadRequest(result);
            }

            return Ok(new BaseResponseModel<TrangThaiGhiEntity?>(statusCode: StatusCodes.Status200OK, code: ResponseCodeConstants.SUCCESS, data: data));
        }

        [HttpPost]
        [Route(WebApiEndpoint.TrangThaiGhi.AddTrangThaiGhi)]
        public async Task<IActionResult> CreateTrangThaiGhi(TrangThaiGhiModel TrangThaiGhi)
        {
            try
            {
                var result = await _iTrangThaiGhiService.CreateAsync(TrangThaiGhi);
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
        [Route(WebApiEndpoint.TrangThaiGhi.UpdateTrangThaiGhi)]
        public async Task<IActionResult> UpdateTrangThaiGhi(string keyId, TrangThaiGhiModel request)
        {
            try
            {
                await _iTrangThaiGhiService.UpdateAsync(keyId, request);
                return Ok(new BaseResponseModel<string>(statusCode: StatusCodes.Status202Accepted, code: ResponseCodeConstants.SUCCESS, data: ReponseMessageConstantsTrangThaiGhi.TRANG_THAI_GHI_EXISTED));
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
        [Route(WebApiEndpoint.TrangThaiGhi.DeleteTrangThaiGhi)]
        public async Task<IActionResult> DeleteTrangThaiGhi(string keyId)
        {
            try
            {
                await _iTrangThaiGhiService.DeleteAsync(keyId, false);
                return Ok(new BaseResponseModel<string>(statusCode: StatusCodes.Status202Accepted, code: ResponseCodeConstants.SUCCESS, data: ReponseMessageConstantsTrangThaiGhi.DELETE_TRANG_THAI_GHI_SUCCESS));
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
