using Microsoft.AspNetCore.Mvc;
using WaterCity.Contract.Repository.Models;
using WaterCity.Contract.Service;
using WaterCity.Core.Constants;
using WaterCity.Core.Exceptions;
using WaterCity.Core.Models;
using WaterCity.Core.Models.DongHoNuocSuCo;

namespace WaterCity.WebApi.Controllers
{
    [ApiController]
    public class DongHoNuocSuCoController : ControllerBase
    {
        private readonly IDongHoNuocSuCoService _iDongHoNuocSuCoService;

        public DongHoNuocSuCoController(IDongHoNuocSuCoService iDongHoNuocSuCoService)
        {
            _iDongHoNuocSuCoService = iDongHoNuocSuCoService;
        }

        /*[HttpGet]
        [Route(WebApiEndpoint.DongHoNuocSuCo.GetAllDongHoNuocSuCo)]
        public async Task<IActionResult> GetAll()
        {
            var result = await _iDongHoNuocSuCoService.GetAllAsync();
            return Ok(new BaseResponseModel<ICollection<DongHoNuocSuCoEntity>?>(
                statusCode: StatusCodes.Status200OK, 
                code: ResponseCodeConstants.SUCCESS, data: result));
        }

        [HttpGet]
        [Route(WebApiEndpoint.DongHoNuocSuCo.GetDongHoNuocSuCo)]
        public async Task<IActionResult> GetDongHoNuocSuCoById(string keyId)
        {
            var data = await _iDongHoNuocSuCoService.GetByKeyIdAsync(keyId);
            if (data == null)
            {
                var result = new BaseResponseModel<string>(
                    statusCode: StatusCodes.Status400BadRequest, 
                    code: ResponseCodeConstants.NOT_FOUND, 
                    message: ReponseMessageConstantsDongHoNuocSuCo.DONG_HO_NUOC_SU_CO_NOT_FOUND);
                return BadRequest(result);
            }

            return Ok(new BaseResponseModel<DongHoNuocSuCoEntity?>
                    (statusCode: StatusCodes.Status200OK, 
                    code: ResponseCodeConstants.SUCCESS, data: data));
        }*/

        [HttpGet]
        [Route(WebApiEndpoint.DongHoNuocSuCo.GetAllDongHoNuocSuCo)]
        public IActionResult GetAll()
        {
            var result = _iDongHoNuocSuCoService.GetAllAsync();
            return Ok(new BaseResponseModel<ICollection<DongHoNuocSuCoEntity>?>(
                statusCode: StatusCodes.Status200OK,
                code: ResponseCodeConstants.SUCCESS, data: result));
        }

        [HttpGet]
        [Route(WebApiEndpoint.DongHoNuocSuCo.GetDongHoNuocSuCo)]
        public IActionResult GetDongHoNuocSuCoById(string keyId)
        {
            var data = _iDongHoNuocSuCoService.GetByKeyIdAsync(keyId);
            if (data == null)
            {
                var result = new BaseResponseModel<string>(
                    statusCode: StatusCodes.Status400BadRequest,
                    code: ResponseCodeConstants.NOT_FOUND,
                    message: ReponseMessageConstantsDongHoNuocSuCo.DONG_HO_NUOC_SU_CO_NOT_FOUND);
                return BadRequest(result);
            }

            return Ok(new BaseResponseModel<DongHoNuocSuCoEntity?>
                    (statusCode: StatusCodes.Status200OK,
                    code: ResponseCodeConstants.SUCCESS, data: data));
        }

        [HttpPost]
        [Route(WebApiEndpoint.DongHoNuocSuCo.AddDongHoNuocSuCo)]
        public async Task<IActionResult> CreateDongHoNuocSuCo(DongHoNuocSuCoModel model)
        {
            try
            {
                var result = await _iDongHoNuocSuCoService.CreateAsync(model);
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
        [Route(WebApiEndpoint.DongHoNuocSuCo.UpdateDongHoNuocSuCo)]
        public async Task<IActionResult> UpdateDongHoNuocSuCo(string keyId, DongHoNuocSuCoModel model)
        {
            try
            {
                await _iDongHoNuocSuCoService.UpdateAsync(keyId, model);
                return Ok(new BaseResponseModel<string>(
                    statusCode: StatusCodes.Status200OK,
                    code: ResponseCodeConstants.SUCCESS,
                    data: ReponseMessageConstantsDongHoNuocSuCo.UPDATE_DONG_HO_NUOC_SU_CO_SUCCESS));
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
        [Route(WebApiEndpoint.DongHoNuocSuCo.DeleteDongHoNuocSuCo)]
        public async Task<IActionResult> DeleteDongHoNuocSuCo(string keyId)
        {
            try
            {
                await _iDongHoNuocSuCoService.DeleteAsync(keyId, false);
                return Ok(new BaseResponseModel<string>(
                    statusCode: StatusCodes.Status200OK,
                    code: ResponseCodeConstants.SUCCESS,
                    data: ReponseMessageConstantsDongHoNuocSuCo.DELETE_DONG_HO_NUOC_SU_CO_SUCCESS));
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
