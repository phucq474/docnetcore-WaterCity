using Microsoft.AspNetCore.Mvc;
using WaterCity.Contract.Repository.Models;
using WaterCity.Contract.Service;
using WaterCity.Core.Constants;
using WaterCity.Core.Exceptions;
using WaterCity.Core.Models;
using WaterCity.Core.Models.SanPham;

namespace WaterCity.WebApi.Controllers
{
    [ApiController]
    public class SanPhamController : ControllerBase
    {
        private readonly ISanPhamService _iSanPhamService;

        public SanPhamController(ISanPhamService iSanPhamService)
        {
            _iSanPhamService = iSanPhamService;
        }

        /*[HttpGet]
        [Route(WebApiEndpoint.SanPham.GetAllSanPham)]
        public async Task<IActionResult> GetAll()
        {
            var result = await _iSanPhamService.GetAllAsync();
            return Ok(new BaseResponseModel<ICollection<SanPhamEntity>?>(
                statusCode: StatusCodes.Status200OK, 
                code: ResponseCodeConstants.SUCCESS, data: result));
        }

        [HttpGet]
        [Route(WebApiEndpoint.SanPham.GetSanPham)]
        public async Task<IActionResult> GetSanPhamById(string keyId)
        {
            var data = await _iSanPhamService.GetByKeyIdAsync(keyId);
            if (data == null)
            {
                return BadRequest(data);
            }

            return Ok(new BaseResponseModel<SanPhamEntity?>
                    (statusCode: StatusCodes.Status200OK, 
                    code: ResponseCodeConstants.SUCCESS, data: data));
        }*/

        [HttpGet]
        [Route(WebApiEndpoint.SanPham.GetAllSanPham)]
        public IActionResult GetAll()
        {
            var result = _iSanPhamService.GetAllAsync();
            return Ok(new BaseResponseModel<ICollection<SanPhamEntity>?>(
                statusCode: StatusCodes.Status200OK,
                code: ResponseCodeConstants.SUCCESS, data: result));
        }

        [HttpGet]
        [Route(WebApiEndpoint.SanPham.GetSanPham)]
        public IActionResult GetSanPhamById(string keyId)
        {
            var data = _iSanPhamService.GetByKeyIdAsync(keyId);
            if (data == null)
            {
                return BadRequest(data);
            }

            return Ok(new BaseResponseModel<SanPhamEntity?>
                    (statusCode: StatusCodes.Status200OK,
                    code: ResponseCodeConstants.SUCCESS, data: data));
        }

        [HttpPost]
        [Route(WebApiEndpoint.SanPham.AddSanPham)]
        public async Task<IActionResult> CreateSanPham(SanPhamModel model)
        {
            try
            {
                var result = await _iSanPhamService.CreateAsync(model);
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
        [Route(WebApiEndpoint.SanPham.UpdateSanPham)]
        public async Task<IActionResult> UpdateSanPham(string keyId, SanPhamModel model)
        {
            try
            {
                await _iSanPhamService.UpdateAsync(keyId, model);
                return Ok(new BaseResponseModel<string>(
                    statusCode: StatusCodes.Status200OK,
                    code: ResponseCodeConstants.SUCCESS,
                    data: ReponseMessageConstantsSanPham.UPDATE_SANPHAM_SUCCESS));
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
        [Route(WebApiEndpoint.SanPham.DeleteSanPham)]
        public async Task<IActionResult> DeleteSanPham(string keyId)
        {
            try
            {
                await _iSanPhamService.DeleteAsync(keyId, false);
                return Ok(new BaseResponseModel<string>(
                    statusCode: StatusCodes.Status200OK,
                    code: ResponseCodeConstants.SUCCESS,
                    data: ReponseMessageConstantsSanPham.DELETE_SANPHAM_SUCCESS));
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

    }
}
