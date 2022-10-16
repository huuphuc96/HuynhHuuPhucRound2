namespace FilmManagement.Core.Helpers
{
    public static class ResponseHelper
    {
        public class ResponseModel<T>
        {
            public bool Status { get; set; }
            public string Code { get; set; }
            public string Message { get; set; }
            public T Data { get; set; }
        }
        public class ResponseModel
        {
            public bool Status { get; set; }
            public string Code { get; set; }
            public string Message { get; set; }
            public object Data => null;
        }
        public static ResponseModel<T> Success<T>(
            T data
            , string message = null
            , string code = null
        )
        {
            return ToResponseModel(data, true, message, code);
        }

        public static ResponseModel Success(
            string message = null
            , string code = null
        )
        {
            return ToResponseModel(true, message, code);
        }

        public static ResponseModel<T> Error<T>(
            T data
            , string message = null
            , string code = null
        )
        {
            return ToResponseModel(data, false, message, code);
        }

        public static ResponseModel Error(
            string message = null
            , string code = null
        )
        {
            return ToResponseModel(false, message, code);
        }

        private static ResponseModel<T> ToResponseModel<T>(
            T data
            , bool success = true
            , string message = null
            , string code = null
        )
        {
            var response = new ResponseModel<T>
            {
                Status = success,
                Message = message,
                Code = code,
                Data = data
            };
            return response;
        }

        private static ResponseModel ToResponseModel(
            bool success = true
            , string message = null
            , string code = null
        )
        {
            var response = new ResponseModel
            {
                Status = success,
                Message = message,
                Code = code
            };
            return response;
        }
    }
}
