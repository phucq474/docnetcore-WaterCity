using Microsoft.AspNetCore.Mvc;
using WaterCity.Contract.Repository.Models;
using WaterCity.Contract.Service;
using WaterCity.Core.Constants;
using WaterCity.Core.Exceptions;
using WaterCity.Core.Models;
using WaterCity.Core.Models.ChiTietDonHang;

namespace WaterCity.WebApi.Controllers
{
    [ApiController]
    public class ChiTietDonHangController : ControllerBase
    {
        private readonly IChiTietDonHangService _iChiTietDonHangService;

        public ChiTietDonHangController(IChiTietDonHangService iChiTietDonHangService)
        {
            _iChiTietDonHangService = iChiTietDonHangService;
        }

        /*[HttpGet]
        [Route(WebApiEndpoint.ChiTietDonHang.GetAllChiTietDonHang)]
        public async Task<IActionResult> GetAll()
        {
            var result = await _iChiTietDonHangService.GetAllAsync();
            return Ok(new BaseResponseModel<ICollection<ChiTietDonHangEntity>?>(
                statusCode: StatusCodes.Status200OK, 
                code: ResponseCodeConstants.SUCCESS, data: result));
        }

        [HttpGet]
        [Route(WebApiEndpoint.ChiTietDonHang.GetChiTietDonHang)]
        public async Task<IActionResult> GetChiTietDonHangById(string keyId)
        {
            var data = await _iChiTietDonHangService.GetByKeyIdAsync(keyId);
            if (data == null)
            {
                return BadRequest(data);
            }

            return Ok(new BaseResponseModel<ChiTietDonHangEntity?>
                    (statusCode: StatusCodes.Status200OK, 
                    code: ResponseCodeConstants.SUCCESS, data: data));
        }*/

        [HttpGet]
        [Route(WebApiEndpoint.ChiTietDonHang.GetAllChiTietDonHang)]
        public IActionResult GetAll()
        {
            var result = _iChiTietDonHangService.GetAllAsync();
            return Ok(new BaseResponseModel<ICollection<ChiTietDonHangEntity>?>(
                statusCode: StatusCodes.Status200OK,
                code: ResponseCodeConstants.SUCCESS, data: result));
        }

        [HttpGet]
        [Route(WebApiEndpoint.ChiTietDonHang.GetChiTietDonHang)]
        public IActionResult GetChiTietDonHangById(string keyId)
        {
            var data = _iChiTietDonHangService.GetByKeyIdAsync(keyId);
            if (data == null)
            {
                return BadRequest(data);
            }

            return Ok(new BaseResponseModel<ChiTietDonHangEntity?>
                    (statusCode: StatusCodes.Status200OK,
                    code: ResponseCodeConstants.SUCCESS, data: data));
        }

        [HttpPost]
        [Route(WebApiEndpoint.ChiTietDonHang.AddChiTietDonHang)]
        public async Task<IActionResult> CreateChiTietDonHang(ChiTietDonHangModel model)
        {
            try
            {
                var result = await _iChiTietDonHangService.CreateAsync(model);
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
        [Route(WebApiEndpoint.ChiTietDonHang.UpdateChiTietDonHang)]
        public async Task<IActionResult> UpdateChiTietDonHang(string keyId, ChiTietDonHangModel model)
        {
            try
            {
                await _iChiTietDonHangService.UpdateAsync(keyId, model);
                return Ok(new BaseResponseModel<string>(
                    statusCode: StatusCodes.Status200OK,
                    code: ResponseCodeConstants.SUCCESS,
                    data: ReponseMessageConstantsChiTietDonHang.UPDATE_CHITIETDONHANG_SUCCESS));
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
        [Route(WebApiEndpoint.ChiTietDonHang.DeleteChiTietDonHang)]
        public async Task<IActionResult> DeleteChiTietDonHang(string keyId)
        {
            try
            {
                await _iChiTietDonHangService.DeleteAsync(keyId, false);
                return Ok(new BaseResponseModel<string>(
                    statusCode: StatusCodes.Status200OK,
                    code: ResponseCodeConstants.SUCCESS,
                    data: ReponseMessageConstantsChiTietDonHang.DELETE_CHITIETDONHANG_SUCCESS));
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
