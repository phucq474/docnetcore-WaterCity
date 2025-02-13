using Microsoft.AspNetCore.Mvc;
using WaterCity.Contract.Repository.Models;
using WaterCity.Contract.Service;
using WaterCity.Core.Constants;
using WaterCity.Core.Exceptions;
using WaterCity.Core.Models.KhachHang;
using WaterCity.Core.Models;

namespace WaterCity.WebApi.Controllers
{
    [ApiController]
    public class KhachHangController : ControllerBase
    {
        private readonly IKhachHangService _iKhachHangService;

        public KhachHangController(IKhachHangService iKhachHangService)
        {
            _iKhachHangService = iKhachHangService;
        }

        /*[HttpGet]
        [Route(WebApiEndpoint.KhachHang.GetAllKhachHang)]
        public async Task<IActionResult> GetAll()
        {
            var result = await _iKhachHangService.GetAllAsync();
            return Ok(new BaseResponseModel<ICollection<KhachHangEntity>?>(statusCode: StatusCodes.Status200OK, code: ResponseCodeConstants.SUCCESS, data: result));
        }

        [HttpGet]
        [Route(WebApiEndpoint.KhachHang.GetKhachHang)]
        public async Task<IActionResult> GetKhachHangById(string keyId)
        {
            var data = await _iKhachHangService.GetByKeyIdAsync(keyId);
            if (data == null)
            {
                var result = new BaseResponseModel<string>(statusCode: StatusCodes.Status400BadRequest, code: ResponseCodeConstants.NOT_FOUND, message: ReponseMessageConstantsKhachHang.KHACH_HANG_NOT_FOUND);
                return BadRequest(result);
            }

            return Ok(new BaseResponseModel<KhachHangEntity?>(statusCode: StatusCodes.Status200OK, code: ResponseCodeConstants.SUCCESS, data: data));
        }*/

        [HttpGet]
        [Route(WebApiEndpoint.KhachHang.GetAllKhachHang)]
        public IActionResult GetAll()
        {
            var result = _iKhachHangService.GetAllAsync();
            return Ok(new BaseResponseModel<ICollection<KhachHangEntity>?>(statusCode: StatusCodes.Status200OK, code: ResponseCodeConstants.SUCCESS, data: result));
        }

        [HttpGet]
        [Route(WebApiEndpoint.KhachHang.GetKhachHang)]
        public IActionResult GetKhachHangById(string keyId)
        {
            var data = _iKhachHangService.GetByKeyIdAsync(keyId);
            if (data == null)
            {
                var result = new BaseResponseModel<string>(statusCode: StatusCodes.Status400BadRequest, code: ResponseCodeConstants.NOT_FOUND, message: ReponseMessageConstantsKhachHang.KHACH_HANG_NOT_FOUND);
                return BadRequest(result);
            }

            return Ok(new BaseResponseModel<KhachHangEntity?>(statusCode: StatusCodes.Status200OK, code: ResponseCodeConstants.SUCCESS, data: data));
        }

        [HttpPost]
        [Route(WebApiEndpoint.KhachHang.AddKhachHang)]
        public async Task<IActionResult> CreateKhachHang(KhachHangModel KhachHang)
        {
            try
            {
                var result = await _iKhachHangService.CreateAsync(KhachHang);
                return Ok(new BaseResponseModel<string>(statusCode: StatusCodes.Status201Created, code: ResponseCodeConstants.SUCCESS, data: result));
            }
            catch (Exception e)
            {
                dynamic result;
                if (e is CoreException)
                {
                    var error = (CoreException)e;
                    result = new BaseResponseModel<string>(statusCode: error.StatusCode, code: error.Code, message: error.Message);
                    return BadRequest(result);
                }
                result = new BaseResponseModel<string>(statusCode: StatusCodes.Status500InternalServerError, code: ResponseCodeConstants.FAILED, message: e.Message);
                return BadRequest(result);
            }
        }

        [HttpPut]
        [Route(WebApiEndpoint.KhachHang.UpdateKhachHang)]
        public async Task<IActionResult> UpdateKhachHang(string keyId, KhachHangModel request)
        {
            try
            {
                await _iKhachHangService.UpdateAsync(keyId, request);
                return Ok(new BaseResponseModel<string>(statusCode: StatusCodes.Status202Accepted, code: ResponseCodeConstants.SUCCESS, data: ReponseMessageConstantsKhachHang.UPDATE_KHACH_HANG_SUCCESS));
            }
            catch (Exception e)
            {
                dynamic result;
                if (e is CoreException)
                {
                    CoreException error = (CoreException)e;
                    result = new BaseResponseModel<string>(statusCode: error.StatusCode, code: error.Code, message: error.Message);
                    return BadRequest(result);
                }
                result = new BaseResponseModel<string>(statusCode: StatusCodes.Status500InternalServerError, code: ResponseCodeConstants.FAILED, message: e.Message);
                return BadRequest(result);
            }

        }

        [HttpDelete]
        [Route(WebApiEndpoint.KhachHang.DeleteKhachHang)]
        public async Task<IActionResult> DeleteKhachHang(string keyId)
        {
            try
            {
                await _iKhachHangService.DeleteAsync(keyId, false);
                return Ok(new BaseResponseModel<string>(statusCode: StatusCodes.Status202Accepted, code: ResponseCodeConstants.SUCCESS, data: ReponseMessageConstantsKhachHang.DELETE_KHACH_HANG_SUCCESS));
            }
            catch (Exception e)
            {
                dynamic result;
                if (e is CoreException)
                {
                    CoreException error = (CoreException)e;
                    result = new BaseResponseModel<string>(statusCode: error.StatusCode, code: error.Code, message: error.Message);
                    return BadRequest(result);
                }
                result = new BaseResponseModel<string>(statusCode: StatusCodes.Status500InternalServerError, code: ResponseCodeConstants.FAILED, message: e.Message);
                return BadRequest(result);
            }
        }
    }
}
