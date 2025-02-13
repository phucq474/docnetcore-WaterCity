
using Microsoft.AspNetCore.Mvc;
using WaterCity.Contract.Repository.Models;
using WaterCity.Contract.Service;
using WaterCity.Core.Constants;
using WaterCity.Core.Exceptions;
using WaterCity.Core.Models;
using WaterCity.Core.Models.KieuDongHo;

namespace WaterCity.WebApi.Controllers
{
    [ApiController]
    public class KieuDongHoController : ControllerBase
    {
        private readonly IKieuDongHoService _iKieuDongHoService;

        public KieuDongHoController(IKieuDongHoService iKieuDongHoService)
        {
            _iKieuDongHoService = iKieuDongHoService;
        }

        [HttpGet]
        [Route(WebApiEndpoint.KieuDongHo.GetAllKieuDongHo)]
        public IActionResult GetAll()
        {
            var result = _iKieuDongHoService.GetAllAsync();
            return Ok(new BaseResponseModel<ICollection<KieuDongHoEntity>?>(
                statusCode: StatusCodes.Status200OK,
                code: ResponseCodeConstants.SUCCESS, data: result));
        }

        [HttpGet]
        [Route(WebApiEndpoint.KieuDongHo.GetKieuDongHo)]
        public IActionResult GetKieuDongHoById(string keyId)
        {
            var data = _iKieuDongHoService.GetByKeyIdAsync(keyId);
            if (data == null)
            {
                var result = new BaseResponseModel<string>(
                    statusCode: StatusCodes.Status400BadRequest,
                    code: ResponseCodeConstants.NOT_FOUND,
                    message: ReponseMessageConstantsKieuDongHo.KIEUDONGHO_NOT_FOUND);
                return BadRequest(result);
            }

            return Ok(new BaseResponseModel<KieuDongHoEntity?>
                    (statusCode: StatusCodes.Status200OK,
                    code: ResponseCodeConstants.SUCCESS, data: data));
        }

        [HttpPost]
        [Route(WebApiEndpoint.KieuDongHo.AddKieuDongHo)]
        public async Task<IActionResult> CreateKieuDongHo(KieuDongHoModel model)
        {
            try
            {
                var result = await _iKieuDongHoService.CreateAsync(model);
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
        [Route(WebApiEndpoint.KieuDongHo.UpdateKieuDongHo)]
        public async Task<IActionResult> UpdateKieuDongHo(string keyId, KieuDongHoModel model)
        {
            try
            {
                await _iKieuDongHoService.UpdateAsync(keyId, model);
                return Ok(new BaseResponseModel<string>(
                    statusCode: StatusCodes.Status200OK,
                    code: ResponseCodeConstants.SUCCESS,
                    data: ReponseMessageConstantsKieuDongHo.UPDATE_KIEUDONGHO_SUCCESS));
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
        [Route(WebApiEndpoint.KieuDongHo.DeleteKieuDongHo)]
        public async Task<IActionResult> DeleteKieuDongHo(string keyId)
        {
            try
            {
                await _iKieuDongHoService.DeleteAsync(keyId, false);
                return Ok(new BaseResponseModel<string>(
                    statusCode: StatusCodes.Status200OK,
                    code: ResponseCodeConstants.SUCCESS,
                    data: ReponseMessageConstantsKieuDongHo.DELETE_KIEUDONGHO_SUCCESS));
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
