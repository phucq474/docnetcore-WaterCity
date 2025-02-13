using Microsoft.AspNetCore.Mvc;
using WaterCity.Contract.Repository.Models;
using WaterCity.Contract.Service;
using WaterCity.Core.Constants;
using WaterCity.Core.Exceptions;
using WaterCity.Core.Models;
using WaterCity.Core.Models.DonHang;

namespace WaterCity.WebApi.Controllers
{
    [ApiController]
    public class DonHangController : ControllerBase
    {
        private readonly IDonHangService _iDonHangService;

        public DonHangController(IDonHangService iDonHangService)
        {
            _iDonHangService = iDonHangService;
        }

        /*[HttpGet]
        [Route(WebApiEndpoint.DonHang.GetAllDonHang)]
        public async Task<IActionResult> GetAll()
        {
            var result = await _iDonHangService.GetAllAsync();
            return Ok(new BaseResponseModel<ICollection<DonHangEntity>?>(
                statusCode: StatusCodes.Status200OK, 
                code: ResponseCodeConstants.SUCCESS, data: result));
        }

        [HttpGet]
        [Route(WebApiEndpoint.DonHang.GetDonHang)]
        public async Task<IActionResult> GetDonHangById(string keyId)
        {
            var data = await _iDonHangService.GetByKeyIdAsync(keyId);
            if (data == null)
            {
                return BadRequest(data);
            }

            return Ok(new BaseResponseModel<DonHangEntity?>
                    (statusCode: StatusCodes.Status200OK, 
                    code: ResponseCodeConstants.SUCCESS, data: data));
        }*/

        [HttpGet]
        [Route(WebApiEndpoint.DonHang.GetAllDonHang)]
        public IActionResult GetAll()
        {
            var result = _iDonHangService.GetAllAsync();
            return Ok(new BaseResponseModel<ICollection<DonHangEntity>?>(
                statusCode: StatusCodes.Status200OK,
                code: ResponseCodeConstants.SUCCESS, data: result));
        }

        [HttpGet]
        [Route(WebApiEndpoint.DonHang.GetDonHang)]
        public IActionResult GetDonHangById(string keyId)
        {
            var data = _iDonHangService.GetByKeyIdAsync(keyId);
            if (data == null)
            {
                return BadRequest(data);
            }

            return Ok(new BaseResponseModel<DonHangEntity?>
                    (statusCode: StatusCodes.Status200OK,
                    code: ResponseCodeConstants.SUCCESS, data: data));
        }

        [HttpPost]
        [Route(WebApiEndpoint.DonHang.AddDonHang)]
        public async Task<IActionResult> CreateDonHang(DonHangModel model)
        {
            try
            {
                var result = await _iDonHangService.CreateAsync(model);
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
        [Route(WebApiEndpoint.DonHang.UpdateDonHang)]
        public async Task<IActionResult> UpdateDonHang(string keyId, DonHangModel model)
        {
            try
            {
                await _iDonHangService.UpdateAsync(keyId, model);
                return Ok(new BaseResponseModel<string>(
                    statusCode: StatusCodes.Status200OK,
                    code: ResponseCodeConstants.SUCCESS,
                    data: ReponseMessageConstantsDonHang.UPDATE_DONHANG_SUCCESS));
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
        [Route(WebApiEndpoint.DonHang.DeleteDonHang)]
        public async Task<IActionResult> DeleteDonHang(string keyId)
        {
            try
            {
                await _iDonHangService.DeleteAsync(keyId, false);
                return Ok(new BaseResponseModel<string>(
                    statusCode: StatusCodes.Status200OK,
                    code: ResponseCodeConstants.SUCCESS,
                    data: ReponseMessageConstantsDonHang.DELETE_DONHANG_SUCCESS));
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
