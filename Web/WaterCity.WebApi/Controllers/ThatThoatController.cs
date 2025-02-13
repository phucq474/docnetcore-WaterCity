using Microsoft.AspNetCore.Mvc;
using WaterCity.Contract.Repository.Models;
using WaterCity.Contract.Service;
using WaterCity.Core.Constants;
using WaterCity.Core.Exceptions;
using WaterCity.Core.Models;
using WaterCity.Core.Models.ThatThoat;

namespace WaterCity.WebApi.Controllers
{
    [ApiController]
    public class ThatThoatController : ControllerBase
    {
        private readonly IThatThoatService _iThatThoatService;

        public ThatThoatController(IThatThoatService iThatThoatService)
        {
            _iThatThoatService = iThatThoatService;
        }

        /*[HttpGet]
        [Route(WebApiEndpoint.ThatThoat.GetAllThatThoat)]
        public async Task<IActionResult> GetAll()
        {
            var result = await _iThatThoatService.GetAllAsync();
            return Ok(new BaseResponseModel<ICollection<ThatThoatEntity>?>(
                statusCode: StatusCodes.Status200OK, 
                code: ResponseCodeConstants.SUCCESS, data: result));
        }

        [HttpGet]
        [Route(WebApiEndpoint.ThatThoat.GetThatThoat)]
        public async Task<IActionResult> GetThatThoatById(string keyId)
        {
            var data = await _iThatThoatService.GetByKeyIdAsync(keyId);
            if (data == null)
            {
                var result = new BaseResponseModel<string>(
                    statusCode: StatusCodes.Status400BadRequest, 
                    code: ResponseCodeConstants.NOT_FOUND, 
                    message: ReponseMessageConstantsThatThoat.THAT_THOAT_NOT_FOUND);
                return BadRequest(result);
            }

            return Ok(new BaseResponseModel<ThatThoatEntity?>
                    (statusCode: StatusCodes.Status200OK, 
                    code: ResponseCodeConstants.SUCCESS, data: data));
        }*/

        [HttpGet]
        [Route(WebApiEndpoint.ThatThoat.GetAllThatThoat)]
        public IActionResult GetAll()
        {
            var result = _iThatThoatService.GetAllAsync();
            return Ok(new BaseResponseModel<ICollection<ThatThoatEntity>?>(
                statusCode: StatusCodes.Status200OK,
                code: ResponseCodeConstants.SUCCESS, data: result));
        }

        [HttpGet]
        [Route(WebApiEndpoint.ThatThoat.GetThatThoat)]
        public IActionResult GetThatThoatById(string keyId)
        {
            var data = _iThatThoatService.GetByKeyIdAsync(keyId);
            if (data == null)
            {
                var result = new BaseResponseModel<string>(
                    statusCode: StatusCodes.Status400BadRequest,
                    code: ResponseCodeConstants.NOT_FOUND,
                    message: ReponseMessageConstantsThatThoat.THAT_THOAT_NOT_FOUND);
                return BadRequest(result);
            }

            return Ok(new BaseResponseModel<ThatThoatEntity?>
                    (statusCode: StatusCodes.Status200OK,
                    code: ResponseCodeConstants.SUCCESS, data: data));
        }

        [HttpPost]
        [Route(WebApiEndpoint.ThatThoat.AddThatThoat)]
        public async Task<IActionResult> CreateThatThoat(ThatThoatModel model)
        {
            try
            {
                var result = await _iThatThoatService.CreateAsync(model);
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
        [Route(WebApiEndpoint.ThatThoat.UpdateThatThoat)]
        public async Task<IActionResult> UpdateThatThoat(string keyId, ThatThoatModel model)
        {
            try
            {
                await _iThatThoatService.UpdateAsync(keyId, model);
                return Ok(new BaseResponseModel<string>(
                    statusCode: StatusCodes.Status200OK,
                    code: ResponseCodeConstants.SUCCESS,
                    data: ReponseMessageConstantsThatThoat.UPDATE_THAT_THOAT_SUCCESS));
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
        [Route(WebApiEndpoint.ThatThoat.DeleteThatThoat)]
        public async Task<IActionResult> DeleteThatThoat(string keyId)
        {
            try
            {
                await _iThatThoatService.DeleteAsync(keyId, false);
                return Ok(new BaseResponseModel<string>(
                    statusCode: StatusCodes.Status200OK,
                    code: ResponseCodeConstants.SUCCESS,
                    data: ReponseMessageConstantsThatThoat.DELETE_THAT_THOAT_SUCCESS));
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
