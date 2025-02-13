#region TinhCu
/*using Microsoft.AspNetCore.Mvc;
using WaterCity.Contract.Repository.Models;
using WaterCity.Contract.Service;
using WaterCity.Core.Constants;
using WaterCity.Core.Models;
using WaterCity.Core.Models.Tinh;

namespace WaterCity.WebApi.Controllers
{
    [ApiController]
    public class TinhController : ControllerBase
    {
        private readonly ITinhService _iTinhService;

        public TinhController(ITinhService iTinhService)
        {
            _iTinhService = iTinhService;
        }

        [HttpGet]
        [Route(WebApiEndpoint.Tinh.GetAllTinh)]
        public IActionResult GetAll()
        {
            var result = _iTinhService.GetAllTinh();
            return Ok(new BaseResponseModel<ICollection<TinhModel>?>
                      (statusCode: StatusCodes.Status200OK,
                       code: ResponseCodeConstants.SUCCESS,
                       data: result));
        }

        [HttpGet()]
        [Route(WebApiEndpoint.Tinh.GetTinh)]
        public IActionResult GetTinhById(string id)
        {
            var data = _iTinhService.GetTinhById(id);
            if (data == null)
            {
                var result = new BaseResponseModel<string>
                    (statusCode: StatusCodes.Status400BadRequest,
                     code: ResponseCodeConstants.NOT_FOUND,
                     message: ReponseMessageConstants.Tinh_NOT_FOUND);
                return BadRequest(result);
            }

            return Ok(new BaseResponseModel<TinhEntity?>
                       (statusCode: StatusCodes.Status200OK,
                        code: ResponseCodeConstants.SUCCESS,
                        data: data));
        }

        [HttpPost]
        [Route(WebApiEndpoint.Tinh.AddTinh)]
        public async Task<IActionResult> CreateTinh(TinhModel request)
        {
            
            var result = await _iTinhService.CreateTinhAsync(request);
            return Ok(new BaseResponseModel<string>
                    (statusCode: StatusCodes.Status200OK,
                     code: ResponseCodeConstants.SUCCESS,
                     data: result));
        }

        [HttpPost()]
        [Route(WebApiEndpoint.Tinh.UpdateTinh)]
        public IActionResult UpdateTinh(TinhModel request)
        {
            try
            {
                var checkTinh = _iTinhService.GetTinhById(request.Id);
                if (checkTinh == null)
                {
                    return BadRequest(new BaseResponseModel<string>
                        (statusCode: StatusCodes.Status404NotFound,
                         code: ResponseCodeConstants.NOT_FOUND,
                         data: ReponseMessageConstants.Tinh_NOT_FOUND));
                }
                var result = _iTinhService.UpdateTinh(request);
                return Ok(new BaseResponseModel<string>
                    (statusCode: StatusCodes.Status200OK,
                     code: ResponseCodeConstants.SUCCESS,
                     data: ReponseMessageConstants.UPDATE_Tinh_SUCCESS));

            }
            catch (Exception ex)
            {
                var result = new BaseResponseModel<string>
                     (statusCode: StatusCodes.Status400BadRequest,
                      code: ResponseCodeConstants.FAILED,
                      message: ex.Message);
                return BadRequest(result);
            }
        }

        [HttpPost()]
        [Route(WebApiEndpoint.Tinh.DeleteTinh)]
        public IActionResult DeleteTinh(string id)
        {
            try
            {
                var checkTinh = _iTinhService.GetTinhById(id);
                if (checkTinh == null)
                {
                    return BadRequest(new BaseResponseModel<string>
                        (statusCode: StatusCodes.Status404NotFound,
                         code: ResponseCodeConstants.NOT_FOUND,
                         data: ReponseMessageConstants.Tinh_NOT_FOUND));
                }
                var result = _iTinhService.DeleteTinh(id);
                return Ok(new BaseResponseModel<string>
                    (statusCode: StatusCodes.Status200OK,
                     code: ResponseCodeConstants.SUCCESS,
                     data: ReponseMessageConstants.DELETE_Tinh_SUCCESS));

            }
            catch (Exception ex)
            {
                var result = new BaseResponseModel<string>
                      (statusCode: StatusCodes.Status400BadRequest,
                       code: ResponseCodeConstants.FAILED,
                       message: ex.Message);
                return BadRequest(result);
            }
        }
    }
}
*/

#endregion

using Microsoft.AspNetCore.Mvc;
using WaterCity.Contract.Repository.Models;
using WaterCity.Contract.Service;
using WaterCity.Core.Constants;
using WaterCity.Core.Exceptions;
using WaterCity.Core.Models;
using WaterCity.Core.Models.Tinh;

namespace WaterCity.WebApi.Controllers
{
    [ApiController]
    public class TinhController : ControllerBase
    {
        private readonly ITinhService _iTinhService;

        public TinhController(ITinhService iTinhService)
        {
            _iTinhService = iTinhService;
        }

        [HttpGet]
        [Route(WebApiEndpoint.Tinh.GetAllTinh)]
        public IActionResult GetAll()
        {
            var result = _iTinhService.GetAllAsync();
            return Ok(new BaseResponseModel<ICollection<TinhEntity>?>(
                statusCode: StatusCodes.Status200OK,
                code: ResponseCodeConstants.SUCCESS, data: result));
        }

        [HttpGet]
        [Route(WebApiEndpoint.Tinh.GetTinh)]
        public IActionResult GetTinhById(string keyId)
        {
            var data = _iTinhService.GetByKeyIdAsync(keyId);
            if (data == null)
            {
                var result = new BaseResponseModel<string>(
                    statusCode: StatusCodes.Status400BadRequest,
                    code: ResponseCodeConstants.NOT_FOUND,
                    message: ReponseMessageConstantsTinh.TINH_NOT_FOUND);
                return BadRequest(result);
            }

            return Ok(new BaseResponseModel<TinhEntity?>
                    (statusCode: StatusCodes.Status200OK,
                    code: ResponseCodeConstants.SUCCESS, data: data));
        }

        [HttpPost]
        [Route(WebApiEndpoint.Tinh.AddTinh)]
        public async Task<IActionResult> CreateTinh(TinhModel model)
        {
            try
            {
                var result = await _iTinhService.CreateAsync(model);
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
        [Route(WebApiEndpoint.Tinh.UpdateTinh)]
        public async Task<IActionResult> UpdateTinh(string keyId, TinhModel model)
        {
            try
            {
                await _iTinhService.UpdateAsync(keyId, model);
                return Ok(new BaseResponseModel<string>(
                    statusCode: StatusCodes.Status200OK,
                    code: ResponseCodeConstants.SUCCESS,
                    data: ReponseMessageConstantsTinh.UPDATE_TINH_SUCCESS));
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
        [Route(WebApiEndpoint.Tinh.DeleteTinh)]
        public async Task<IActionResult> DeleteTinh(string keyId)
        {
            try
            {
                await _iTinhService.DeleteAsync(keyId, false);
                return Ok(new BaseResponseModel<string>(
                    statusCode: StatusCodes.Status200OK,
                    code: ResponseCodeConstants.SUCCESS,
                    data: ReponseMessageConstantsTinh.DELETE_TINH_SUCCESS));
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
