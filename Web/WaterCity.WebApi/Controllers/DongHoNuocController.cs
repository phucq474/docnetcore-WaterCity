using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WaterCity.Contract.Repository.Models;
using WaterCity.Contract.Service;
using WaterCity.Core.Constants;
using WaterCity.Core.Exceptions;
using WaterCity.Core.Models;
using WaterCity.Core.Models.DongHoNuoc;
using WaterCity.Core.Models;
using WaterCity.Service;

namespace WaterCity.WebApi.Controllers
{
    [ApiController]
    public class DongHoNuocController : ControllerBase
    {
        private readonly IDongHoNuocService _iDongHoNuocService;

        public DongHoNuocController(IDongHoNuocService iDongHoNuocService)
        {
            _iDongHoNuocService = iDongHoNuocService;
        }

        /*[HttpGet]
        [Route(WebApiEndpoint.DongHoNuoc.GetAllDongHoNuoc)]
        public async Task<IActionResult> GetAll()
        {
            var result = await _iDongHoNuocService.GetAllAsync();
            return Ok(new BaseResponseModel<ICollection<DongHoNuocEntity>?>(
                statusCode: StatusCodes.Status200OK, 
                code: ResponseCodeConstants.SUCCESS, data: result));
        }

        [HttpGet]
        [Route(WebApiEndpoint.DongHoNuoc.GetDongHoNuoc)]
        public async Task<IActionResult> GetDongHoNuocById(string keyId)
        {
            var data = await _iDongHoNuocService.GetByKeyIdAsync(keyId);
            if (data == null)
            {
                return BadRequest(data);
            }

            return Ok(new BaseResponseModel<DongHoNuocEntity?>
                    (statusCode: StatusCodes.Status200OK, 
                    code: ResponseCodeConstants.SUCCESS, data: data));
        }*/

        [HttpGet]
        [Route(WebApiEndpoint.DongHoNuoc.GetAllDongHoNuoc)]
        public IActionResult GetAll()
        {
            var result = _iDongHoNuocService.GetAllAsync();
            return Ok(new BaseResponseModel<ICollection<DongHoNuocEntity>?>(
                statusCode: StatusCodes.Status200OK,
                code: ResponseCodeConstants.SUCCESS, data: result));
        }

        [HttpGet]
        [Route(WebApiEndpoint.DongHoNuoc.GetDongHoNuoc)]
        public IActionResult GetDongHoNuocById(string keyId)
        {
            var data = _iDongHoNuocService.GetByKeyIdAsync(keyId);
            if (data == null)
            {
                return BadRequest(data);
            }

            return Ok(new BaseResponseModel<DongHoNuocEntity?>
                    (statusCode: StatusCodes.Status200OK,
                    code: ResponseCodeConstants.SUCCESS, data: data));
        }

        [HttpPost]
        [Route(WebApiEndpoint.DongHoNuoc.AddDongHoNuoc)]
        public async Task<IActionResult> CreateDongHoNuoc(DongHoNuocModel model)
        {
            try
            {
                var result = await _iDongHoNuocService.CreateAsync(model);
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
        [Route(WebApiEndpoint.DongHoNuoc.UpdateDongHoNuoc)]
        public async Task<IActionResult> UpdateDongHoNuoc(string keyId, DongHoNuocModel model)
        {
            try
            {
                await _iDongHoNuocService.UpdateAsync(keyId, model);
                return Ok(new BaseResponseModel<string>(
                    statusCode: StatusCodes.Status200OK,
                    code: ResponseCodeConstants.SUCCESS,
                    data: ReponseMessageConstantsDongHoNuoc.UPDATE_DONG_HO_NUOC_SUCCESS));
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
        [Route(WebApiEndpoint.DongHoNuoc.DeleteDongHoNuoc)]
        public async Task<IActionResult> DeleteDongHoNuoc(string keyId)
        {
            try
            {
                await _iDongHoNuocService.DeleteAsync(keyId, false);
                return Ok(new BaseResponseModel<string>(
                    statusCode: StatusCodes.Status200OK,
                    code: ResponseCodeConstants.SUCCESS,
                    data: ReponseMessageConstantsDongHoNuoc.DELETE_DONG_HO_NUOC_SUCCESS));
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
