using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WaterCity.Contract.Repository.Models;
using WaterCity.Contract.Service;
using WaterCity.Core.Constants;
using WaterCity.Core.Exceptions;
using WaterCity.Core.Models.ChiTietHoaDon;
using WaterCity.Core.Models;

namespace WaterCity.WebApi.Controllers
{
    [ApiController]
    public class ChiTietHoaDonController : ControllerBase
    {
        private readonly IChiTietHoaDonService _iChiTietHoaDonService;

        public ChiTietHoaDonController(IChiTietHoaDonService iChiTietHoaDonService)
        {
            _iChiTietHoaDonService = iChiTietHoaDonService;
        }

        /*[HttpGet]
        [Route(WebApiEndpoint.ChiTietHoaDon.GetAllChiTietHoaDon)]
        public async Task<IActionResult> GetAll()
        {
            var result = await _iChiTietHoaDonService.GetAllAsync();
            return Ok(new BaseResponseModel<ICollection<ChiTietHoaDonEntity>?>(statusCode: StatusCodes.Status200OK, code: ResponseCodeConstants.SUCCESS, data: result));
        }

        [HttpGet]
        [Route(WebApiEndpoint.ChiTietHoaDon.GetChiTietHoaDon)]
        public async Task<IActionResult> GetChiTietHoaDonById(string keyId)
        {
            var data = await _iChiTietHoaDonService.GetByKeyIdAsync(keyId);
            if (data == null)
            {
                var result = new BaseResponseModel<string>(statusCode: StatusCodes.Status400BadRequest, code: ResponseCodeConstants.NOT_FOUND, message: ReponseMessageConstantsChiTietHoaDon.CHI_TIET_HOA_DON_NOT_FOUND);
                return BadRequest(result);
            }

            return Ok(new BaseResponseModel<ChiTietHoaDonEntity?>(statusCode: StatusCodes.Status200OK, code: ResponseCodeConstants.SUCCESS, data: data));
        }*/

        [HttpGet]
        [Route(WebApiEndpoint.ChiTietHoaDon.GetAllChiTietHoaDon)]
        public IActionResult GetAll()
        {
            var result = _iChiTietHoaDonService.GetAllAsync();
            return Ok(new BaseResponseModel<ICollection<ChiTietHoaDonEntity>?>(statusCode: StatusCodes.Status200OK, code: ResponseCodeConstants.SUCCESS, data: result));
        }

        [HttpGet]
        [Route(WebApiEndpoint.ChiTietHoaDon.GetChiTietHoaDon)]
        public IActionResult GetChiTietHoaDonById(string keyId)
        {
            var data = _iChiTietHoaDonService.GetByKeyIdAsync(keyId);
            if (data == null)
            {
                var result = new BaseResponseModel<string>(statusCode: StatusCodes.Status400BadRequest, code: ResponseCodeConstants.NOT_FOUND, message: ReponseMessageConstantsChiTietHoaDon.CHI_TIET_HOA_DON_NOT_FOUND);
                return BadRequest(result);
            }

            return Ok(new BaseResponseModel<ChiTietHoaDonEntity?>(statusCode: StatusCodes.Status200OK, code: ResponseCodeConstants.SUCCESS, data: data));
        }

        [HttpPost]
        [Route(WebApiEndpoint.ChiTietHoaDon.AddChiTietHoaDon)]
        public async Task<IActionResult> CreateChiTietHoaDon(ChiTietHoaDonModel ChiTietHoaDon)
        {
            try
            {
                var result = await _iChiTietHoaDonService.CreateAsync(ChiTietHoaDon);
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
        [Route(WebApiEndpoint.ChiTietHoaDon.UpdateChiTietHoaDon)]
        public async Task<IActionResult> UpdateChiTietHoaDon(string keyId, ChiTietHoaDonModel request)
        {
            try
            {
                await _iChiTietHoaDonService.UpdateAsync(keyId, request);
                return Ok(new BaseResponseModel<string>(statusCode: StatusCodes.Status202Accepted, code: ResponseCodeConstants.SUCCESS, data: ReponseMessageConstantsChiTietHoaDon.UPDATE_CHI_TIET_HOA_DON_SUCCESS));
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
        [Route(WebApiEndpoint.ChiTietHoaDon.DeleteChiTietHoaDon)]
        public async Task<IActionResult> DeleteChiTietHoaDon(string keyId)
        {
            try
            {
                await _iChiTietHoaDonService.DeleteAsync(keyId, false);
                return Ok(new BaseResponseModel<string>(statusCode: StatusCodes.Status202Accepted, code: ResponseCodeConstants.SUCCESS, data: ReponseMessageConstantsChiTietHoaDon.DELETE_CHI_TIET_HOA_DON_SUCCESS));
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
