
using Microsoft.AspNetCore.Mvc;
using WaterCity.Contract.Repository.Models;
using WaterCity.Contract.Service;
using WaterCity.Core.Constants;
using WaterCity.Core.Exceptions;
using WaterCity.Core.Models;
using WaterCity.Core.Models.HangSanXuat;

namespace WaterCity.WebApi.Controllers
{
    [ApiController]
    public class HangSanXuatController : ControllerBase
    {
        private readonly IHangSanXuatService _iHangSanXuatService;

        public HangSanXuatController(IHangSanXuatService iHangSanXuatService)
        {
            _iHangSanXuatService = iHangSanXuatService;
        }

        [HttpGet]
        [Route(WebApiEndpoint.HangSanXuat.GetAllHangSanXuat)]
        public IActionResult GetAll()
        {
            var result = _iHangSanXuatService.GetAllAsync();
            return Ok(new BaseResponseModel<ICollection<HangSanXuatEntity>?>(
                statusCode: StatusCodes.Status200OK,
                code: ResponseCodeConstants.SUCCESS, data: result));
        }

        [HttpGet]
        [Route(WebApiEndpoint.HangSanXuat.GetHangSanXuat)]
        public IActionResult GetHangSanXuatById(string keyId)
        {
            var data = _iHangSanXuatService.GetByKeyIdAsync(keyId);
            if (data == null)
            {
                var result = new BaseResponseModel<string>(
                    statusCode: StatusCodes.Status400BadRequest,
                    code: ResponseCodeConstants.NOT_FOUND,
                    message: ReponseMessageConstantsHangSanXuat.HANGSANXUAT_NOT_FOUND);
                return BadRequest(result);
            }

            return Ok(new BaseResponseModel<HangSanXuatEntity?>
                    (statusCode: StatusCodes.Status200OK,
                    code: ResponseCodeConstants.SUCCESS, data: data));
        }

        [HttpPost]
        [Route(WebApiEndpoint.HangSanXuat.AddHangSanXuat)]
        public async Task<IActionResult> CreateHangSanXuat(HangSanXuatModel model)
        {
            try
            {
                var result = await _iHangSanXuatService.CreateAsync(model);
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
        [Route(WebApiEndpoint.HangSanXuat.UpdateHangSanXuat)]
        public async Task<IActionResult> UpdateHangSanXuat(string keyId, HangSanXuatModel model)
        {
            try
            {
                await _iHangSanXuatService.UpdateAsync(keyId, model);
                return Ok(new BaseResponseModel<string>(
                    statusCode: StatusCodes.Status200OK,
                    code: ResponseCodeConstants.SUCCESS,
                    data: ReponseMessageConstantsHangSanXuat.UPDATE_HANGSANXUAT_SUCCESS));
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
        [Route(WebApiEndpoint.HangSanXuat.DeleteHangSanXuat)]
        public async Task<IActionResult> DeleteHangSanXuat(string keyId)
        {
            try
            {
                await _iHangSanXuatService.DeleteAsync(keyId, false);
                return Ok(new BaseResponseModel<string>(
                    statusCode: StatusCodes.Status200OK,
                    code: ResponseCodeConstants.SUCCESS,
                    data: ReponseMessageConstantsHangSanXuat.DELETE_HANGSANXUAT_SUCCESS));
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
