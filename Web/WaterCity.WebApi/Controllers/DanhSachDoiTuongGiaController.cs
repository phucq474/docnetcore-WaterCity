using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using WaterCity.Contract.Repository.Models;
using WaterCity.Contract.Service;
using WaterCity.Core.Constants;
using WaterCity.Core.Exceptions;
using WaterCity.Core.Models;
using WaterCity.Core.Models.DanhSachDoiTuongGia;

namespace WaterCity.WebApi.Controllers
{
    [ApiController]
    public class DanhSachDoiTuongGiaController : ControllerBase
    {
        private readonly IDanhSachDoiTuongGiaService _iDanhSachDoiTuongGiaService;

        public DanhSachDoiTuongGiaController(IDanhSachDoiTuongGiaService iDanhSachDoiTuongGiaService)
        {
            _iDanhSachDoiTuongGiaService = iDanhSachDoiTuongGiaService;
        }

        /*[HttpGet]
        [Route(WebApiEndpoint.DanhSachDoiTuongGia.GetAllDanhSachDoiTuongGia)]
        public async Task<IActionResult> GetAll()
        {
            var result = await _iDanhSachDoiTuongGiaService.GetAllAsync();
            return Ok(new BaseResponseModel<ICollection<DanhSachDoiTuongGiaEntity>?>(
                statusCode: StatusCodes.Status200OK, 
                code: ResponseCodeConstants.SUCCESS, 
                data: result));
        }

        [HttpGet]
        [Route(WebApiEndpoint.DanhSachDoiTuongGia.GetDanhSachDoiTuongGia)]
        public async Task<IActionResult> GetDanhSachDoiTuongGiaById(string keyId)
        {
            var data = await _iDanhSachDoiTuongGiaService.GetByKeyIdAsync(keyId);
            if (data == null)
            {
                var result = new BaseResponseModel<string>(
                    statusCode: StatusCodes.Status400BadRequest, 
                    code: ResponseCodeConstants.NOT_FOUND, 
                    message: ReponseMessageConstantsDanhSachDoiTuongGia.DANH_SACH_DANH_SACH_DOI_TUONG_GIA_NOT_FOUND);
                return BadRequest(result);
            }

            return Ok(new BaseResponseModel<DanhSachDoiTuongGiaEntity?>
                    (statusCode: StatusCodes.Status200OK, 
                    code: ResponseCodeConstants.SUCCESS, data: data));
        }*/

        [HttpGet]
        [Route(WebApiEndpoint.DanhSachDoiTuongGia.GetAllDanhSachDoiTuongGia)]
        public IActionResult GetAll()
        {
            var result = _iDanhSachDoiTuongGiaService.GetAllAsync();
            return Ok(new BaseResponseModel<ICollection<DanhSachDoiTuongGiaEntity>?>(
                statusCode: StatusCodes.Status200OK,
                code: ResponseCodeConstants.SUCCESS,
                data: result));
        }

        [HttpGet]
        [Route(WebApiEndpoint.DanhSachDoiTuongGia.GetDanhSachDoiTuongGia)]
        public IActionResult GetDanhSachDoiTuongGiaById(string keyId)
        {
            var data = _iDanhSachDoiTuongGiaService.GetByKeyIdAsync(keyId);
            if (data == null)
            {
                var result = new BaseResponseModel<string>(
                    statusCode: StatusCodes.Status400BadRequest,
                    code: ResponseCodeConstants.NOT_FOUND,
                    message: ReponseMessageConstantsDanhSachDoiTuongGia.DANH_SACH_DANH_SACH_DOI_TUONG_GIA_NOT_FOUND);
                return BadRequest(result);
            }

            return Ok(new BaseResponseModel<DanhSachDoiTuongGiaEntity?>
                    (statusCode: StatusCodes.Status200OK,
                    code: ResponseCodeConstants.SUCCESS, data: data));
        }

        [HttpPost]
        [Route(WebApiEndpoint.DanhSachDoiTuongGia.AddDanhSachDoiTuongGia)]
        public async Task<IActionResult> CreateDanhSachDoiTuongGia(DanhSachDoiTuongGiaModel model)
        {
            try
            {
                var result = await _iDanhSachDoiTuongGiaService.CreateAsync(model);
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
        [Route(WebApiEndpoint.DanhSachDoiTuongGia.UpdateDanhSachDoiTuongGia)]
        public async Task<IActionResult> UpdateDanhSachDoiTuongGia(string keyId, DanhSachDoiTuongGiaModel request)
        {
            try
            {
                await _iDanhSachDoiTuongGiaService.UpdateAsync(keyId, request);
                return Ok(new BaseResponseModel<string>(
                    statusCode: StatusCodes.Status200OK,
                    code: ResponseCodeConstants.SUCCESS,
                    data: ReponseMessageConstantsDanhSachDoiTuongGia.UPDATE_DANH_SACH_DOI_TUONG_GIA_SUCCESS));
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
        [Route(WebApiEndpoint.DanhSachDoiTuongGia.DeleteDanhSachDoiTuongGia)]
        public async Task<IActionResult> DeleteDanhSachDoiTuongGia(string keyId)
        {
            try
            {
                await _iDanhSachDoiTuongGiaService.DeleteAsync(keyId, false);
                return Ok(new BaseResponseModel<string>(
                    statusCode: StatusCodes.Status200OK,
                    code: ResponseCodeConstants.SUCCESS,
                    data: ReponseMessageConstantsDanhSachDoiTuongGia.DELETE_DANH_SACH_DOI_TUONG_GIA_SUCCESS));
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
                result = new BaseResponseModel<string>(statusCode: StatusCodes.Status500InternalServerError, code: ResponseCodeConstants.FAILED, message: e.Message);
                return BadRequest(result);
            }
        }
    }
}
