using Microsoft.AspNetCore.Mvc;
using WaterCity.Contract.Repository.Models;
using WaterCity.Contract.Service;
using WaterCity.Core.Constants;
using WaterCity.Core.Exceptions;
using WaterCity.Core.Models.ChiSoDongHo;
using WaterCity.Core.Models;
using WaterCity.Service;

namespace WaterCity.WebApi.Controllers
{
    [ApiController]
    public class ChiSoDongHoController : ControllerBase
    {
        private readonly IChiSoDongHoService _iChiSoDongHoService;

        public ChiSoDongHoController(IChiSoDongHoService iChiSoDongHoService)
        {
            _iChiSoDongHoService = iChiSoDongHoService;
        }

        /*[HttpGet]
        [Route(WebApiEndpoint.ChiSoDongHo.GetAllChiSoDongHo)]
        public async Task<IActionResult> GetAll()
        {
            var result = await _iChiSoDongHoService.GetAllAsync();
            return Ok(new BaseResponseModel<ICollection<ChiSoDongHoEntity>?>(statusCode: StatusCodes.Status200OK, code: ResponseCodeConstants.SUCCESS, data: result));
        }

        [HttpGet]
        [Route(WebApiEndpoint.ChiSoDongHo.GetChiSoDongHo)]
        public async Task<IActionResult> GetChiSoDongHoById(string keyId)
        {
            var data = await _iChiSoDongHoService.GetByKeyIdAsync(keyId);
            if (data == null)
            {
                var result = new BaseResponseModel<string>(statusCode: StatusCodes.Status400BadRequest, code: ResponseCodeConstants.NOT_FOUND, message: ReponseMessageConstantsChiSoDongHo.CHI_SO_DONG_HO_NOT_FOUND);
                return BadRequest(result);
            }

            return Ok(new BaseResponseModel<ChiSoDongHoEntity?>(statusCode: StatusCodes.Status200OK, code: ResponseCodeConstants.SUCCESS, data: data));
        }*/

        [HttpGet]
        [Route(WebApiEndpoint.ChiSoDongHo.GetAllChiSoDongHo)]
        public IActionResult GetAll()
        {
            var result = _iChiSoDongHoService.GetAllAsync();
            return Ok(new BaseResponseModel<ICollection<ChiSoDongHoEntity>?>(statusCode: StatusCodes.Status200OK, code: ResponseCodeConstants.SUCCESS, data: result));
        }

        [HttpGet]
        [Route(WebApiEndpoint.ChiSoDongHo.GetChiSoDongHo)]
        public IActionResult GetChiSoDongHoById(string keyId)
        {
            var data = _iChiSoDongHoService.GetByKeyIdAsync(keyId);
            if (data == null)
            {
                var result = new BaseResponseModel<string>(statusCode: StatusCodes.Status400BadRequest, code: ResponseCodeConstants.NOT_FOUND, message: ReponseMessageConstantsChiSoDongHo.CHI_SO_DONG_HO_NOT_FOUND);
                return BadRequest(result);
            }

            return Ok(new BaseResponseModel<ChiSoDongHoEntity?>(statusCode: StatusCodes.Status200OK, code: ResponseCodeConstants.SUCCESS, data: data));
        }

        [HttpPost]
        [Route(WebApiEndpoint.ChiSoDongHo.AddChiSoDongHo)]
        public async Task<IActionResult> CreateChiSoDongHo(ChiSoDongHoModel ChiSoDongHo)
        {
            try
            {
                var result = await _iChiSoDongHoService.CreateAsync(ChiSoDongHo);
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
        [Route(WebApiEndpoint.ChiSoDongHo.UpdateChiSoDongHo)]
        public async Task<IActionResult> UpdateChiSoDongHo(string keyId, ChiSoDongHoModel request)
        {
            try
            {
                await _iChiSoDongHoService.UpdateAsync(keyId, request);
                return Ok(new BaseResponseModel<string>(statusCode: StatusCodes.Status202Accepted, code: ResponseCodeConstants.SUCCESS, data: ReponseMessageConstantsChiSoDongHo.UPDATE_CHI_SO_DONG_HO_SUCCESS));
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
        [Route(WebApiEndpoint.ChiSoDongHo.DeleteChiSoDongHo)]
        public async Task<IActionResult> DeleteChiSoDongHo(string keyId)
        {
            try
            {
                await _iChiSoDongHoService.DeleteAsync(keyId, false);
                return Ok(new BaseResponseModel<string>(statusCode: StatusCodes.Status202Accepted, code: ResponseCodeConstants.SUCCESS, data: ReponseMessageConstantsChiSoDongHo.DELETE_CHI_SO_DONG_HO_SUCCESS));
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
