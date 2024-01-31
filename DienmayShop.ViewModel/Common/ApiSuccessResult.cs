namespace DienmayShop.ViewModel.Common
{
    public class ApiSuccessResult<T> : ApiResult<T>
    {
        public ApiSuccessResult(T resultObj)
        {
            IsSuccessed = true;
            ResultObj = resultObj;
            Message = "Thành công";
        }
        public ApiSuccessResult()
        {
            IsSuccessed = true;
            Message = "Thành công";
        }
    }
}
