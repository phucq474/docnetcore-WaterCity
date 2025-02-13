using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WaterCity.Contract.Repository.Models;
using WaterCity.Contract.Service;
using WaterCity.Core.Constants;
using WaterCity.Core.Exceptions;
using WaterCity.Core.Models.DanhSachHoDan;
using WaterCity.Core.Models;

namespace WaterCity.WebApi.Controllers
{
    [ApiController]
    public class DanhSachHoDanController : ControllerBase
    {
        private readonly IDanhSachHoDanService _iDanhSachHoDanService;

        public DanhSachHoDanController(IDanhSachHoDanService iDanhSachHoDanService)
        {
            _iDanhSachHoDanService = iDanhSachHoDanService;
        }

        /*[HttpGet]
        [Route(WebApiEndpoint.DanhSachHoDan.GetAllDanhSachHoDan)]
        public async Task<IActionResult> GetAll()
        {
            var result = await _iDanhSachHoDanService.GetAllAsync();
            return Ok(new BaseResponseModel<ICollection<DanhSachHoDanEntity>?>(statusCode: StatusCodes.Status200OK, code: ResponseCodeConstants.SUCCESS, data: result));
        }

        [HttpGet]
        [Route(WebApiEndpoint.DanhSachHoDan.GetDanhSachHoDan)]
        public async Task<IActionResult> GetDanhSachHoDanById(string keyId)
        {
            var data = await _iDanhSachHoDanService.GetByKeyIdAsync(keyId);
            if (data == null)
            {
                var result = new BaseResponseModel<string>(statusCode: StatusCodes.Status400BadRequest, code: ResponseCodeConstants.NOT_FOUND, message: ReponseMessageConstantsDanhSachHoDan.DANH_SACH_HO_DAN_NOT_FOUND);
                return BadRequest(result);
            }

            return Ok(new BaseResponseModel<DanhSachHoDanEntity?>(statusCode: StatusCodes.Status200OK, code: ResponseCodeConstants.SUCCESS, data: data));
        }*/

        [HttpGet]
        [Route(WebApiEndpoint.DanhSachHoDan.GetAllDanhSachHoDan)]
        public IActionResult GetAll()
        {
            var result = _iDanhSachHoDanService.GetAllAsync();
            return Ok(new BaseResponseModel<ICollection<DanhSachHoDanEntity>?>(statusCode: StatusCodes.Status200OK, code: ResponseCodeConstants.SUCCESS, data: result));
        }

        [HttpGet]
        [Route(WebApiEndpoint.DanhSachHoDan.GetDanhSachHoDan)]
        public IActionResult GetDanhSachHoDanById(string keyId)
        {
            var data = _iDanhSachHoDanService.GetByKeyIdAsync(keyId);
            if (data == null)
            {
                var result = new BaseResponseModel<string>(statusCode: StatusCodes.Status400BadRequest, code: ResponseCodeConstants.NOT_FOUND, message: ReponseMessageConstantsDanhSachHoDan.DANH_SACH_HO_DAN_NOT_FOUND);
                return BadRequest(result);
            }

            return Ok(new BaseResponseModel<DanhSachHoDanEntity?>(statusCode: StatusCodes.Status200OK, code: ResponseCodeConstants.SUCCESS, data: data));
        }

        [HttpPost]
        [Route(WebApiEndpoint.DanhSachHoDan.AddDanhSachHoDan)]
        public async Task<IActionResult> CreateDanhSachHoDan(DanhSachHoDanModel DanhSachHoDan)
        {
            try
            {
                var result = await _iDanhSachHoDanService.CreateAsync(DanhSachHoDan);
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
        [Route(WebApiEndpoint.DanhSachHoDan.UpdateDanhSachHoDan)]
        public async Task<IActionResult> UpdateDanhSachHoDan(string keyId, DanhSachHoDanModel request)
        {
            try
            {
                await _iDanhSachHoDanService.UpdateAsync(keyId, request);
                return Ok(new BaseResponseModel<string>(statusCode: StatusCodes.Status202Accepted, code: ResponseCodeConstants.SUCCESS, data: ReponseMessageConstantsDanhSachHoDan.UPDATE_DANH_SACH_HO_DAN_SUCCESS));
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
        [Route(WebApiEndpoint.DanhSachHoDan.DeleteDanhSachHoDan)]
        public async Task<IActionResult> DeleteDanhSachHoDan(string keyId)
        {
            try
            {
                await _iDanhSachHoDanService.DeleteAsync(keyId, false);
                return Ok(new BaseResponseModel<string>(statusCode: StatusCodes.Status202Accepted, code: ResponseCodeConstants.SUCCESS, data: ReponseMessageConstantsDanhSachHoDan.DELETE_DANH_SACH_HO_DAN_SUCCESS));
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
