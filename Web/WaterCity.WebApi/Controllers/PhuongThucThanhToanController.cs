using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WaterCity.Contract.Repository.Models;
using WaterCity.Contract.Service;
using WaterCity.Core.Constants;
using WaterCity.Core.Exceptions;
using WaterCity.Core.Models.PhuongThucThanhToan;
using WaterCity.Core.Models;

namespace WaterCity.WebApi.Controllers
{
    [ApiController]
    public class PhuongThucThanhToanController : ControllerBase
    {
        private readonly IPhuongThucThanhToanService _iPhuongThucThanhToanService;

        public PhuongThucThanhToanController(IPhuongThucThanhToanService iPhuongThucThanhToanService)
        {
            _iPhuongThucThanhToanService = iPhuongThucThanhToanService;
        }

        /*[HttpGet]
        [Route(WebApiEndpoint.PhuongThucThanhToan.GetAllPhuongThucThanhToan)]
        public async Task<IActionResult> GetAll()
        {
            var result = await _iPhuongThucThanhToanService.GetAllAsync();
            return Ok(new BaseResponseModel<ICollection<PhuongThucThanhToanEntity>?>(statusCode: StatusCodes.Status200OK, code: ResponseCodeConstants.SUCCESS, data: result));
        }

        [HttpGet]
        [Route(WebApiEndpoint.PhuongThucThanhToan.GetPhuongThucThanhToan)]
        public async Task<IActionResult> GetPhuongThucThanhToanById(string keyId)
        {
            var data = await _iPhuongThucThanhToanService.GetByKeyIdAsync(keyId);
            if (data == null)
            {
                var result = new BaseResponseModel<string>(statusCode: StatusCodes.Status400BadRequest, code: ResponseCodeConstants.NOT_FOUND, message: ReponseMessageConstantsPhuongThucThanhToan.PHUONG_THUC_THANH_TOAN_NOT_FOUND);
                return BadRequest(result);
            }

            return Ok(new BaseResponseModel<PhuongThucThanhToanEntity?>(statusCode: StatusCodes.Status200OK, code: ResponseCodeConstants.SUCCESS, data: data));
        }*/

        [HttpGet]
        [Route(WebApiEndpoint.PhuongThucThanhToan.GetAllPhuongThucThanhToan)]
        public IActionResult GetAll()
        {
            var result = _iPhuongThucThanhToanService.GetAllAsync();
            return Ok(new BaseResponseModel<ICollection<PhuongThucThanhToanEntity>?>(statusCode: StatusCodes.Status200OK, code: ResponseCodeConstants.SUCCESS, data: result));
        }

        [HttpGet]
        [Route(WebApiEndpoint.PhuongThucThanhToan.GetPhuongThucThanhToan)]
        public IActionResult GetPhuongThucThanhToanById(string keyId)
        {
            var data = _iPhuongThucThanhToanService.GetByKeyIdAsync(keyId);
            if (data == null)
            {
                var result = new BaseResponseModel<string>(statusCode: StatusCodes.Status400BadRequest, code: ResponseCodeConstants.NOT_FOUND, message: ReponseMessageConstantsPhuongThucThanhToan.PHUONG_THUC_THANH_TOAN_NOT_FOUND);
                return BadRequest(result);
            }

            return Ok(new BaseResponseModel<PhuongThucThanhToanEntity?>(statusCode: StatusCodes.Status200OK, code: ResponseCodeConstants.SUCCESS, data: data));
        }

        [HttpPost]
        [Route(WebApiEndpoint.PhuongThucThanhToan.AddPhuongThucThanhToan)]
        public async Task<IActionResult> CreatePhuongThucThanhToan(PhuongThucThanhToanModel PhuongThucThanhToan)
        {
            try
            {
                var result = await _iPhuongThucThanhToanService.CreateAsync(PhuongThucThanhToan);
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
        [Route(WebApiEndpoint.PhuongThucThanhToan.UpdatePhuongThucThanhToan)]
        public async Task<IActionResult> UpdatePhuongThucThanhToan(string keyId, PhuongThucThanhToanModel request)
        {
            try
            {
                await _iPhuongThucThanhToanService.UpdateAsync(keyId, request);
                return Ok(new BaseResponseModel<string>(statusCode: StatusCodes.Status202Accepted, code: ResponseCodeConstants.SUCCESS, data: ReponseMessageConstantsPhuongThucThanhToan.UPDATE_PHUONG_THUC_THANH_TOAN_SUCCESS));
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
        [Route(WebApiEndpoint.PhuongThucThanhToan.DeletePhuongThucThanhToan)]
        public async Task<IActionResult> DeletePhuongThucThanhToan(string keyId)
        {
            try
            {
                await _iPhuongThucThanhToanService.DeleteAsync(keyId, false);
                return Ok(new BaseResponseModel<string>(statusCode: StatusCodes.Status202Accepted, code: ResponseCodeConstants.SUCCESS, data: ReponseMessageConstantsPhuongThucThanhToan.DELETE_PHUONG_THUC_THANH_TOAN_SUCCESS));
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
