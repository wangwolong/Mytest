using System;

namespace Common
{
    public class WebEntity
    {
        #region JsonR 接口返回的Json对象
        [Serializable]
        public class JsonR
        {
            public JsonR()
            {
                code = -1;
                message = string.Empty;
                body = null;
            }
            /// <summary>
            /// 返回码
            /// </summary>
            public int code { get; set; }
            /// <summary>
            /// 返回说明
            /// </summary>
            public string message { get; set; }
            /// <summary>
            /// 返回数据体 可为空
            /// </summary>
            public object body { get; set; }
        }
        #endregion

        #region JsonR 接口返回的Json对象,<T>
        [Serializable]
        public class JsonR<T>
        {
            public JsonR()
            {
                code = -1;
                message = string.Empty;
                body = default(T);
            }
            /// <summary>
            /// 返回码
            /// </summary>
            public int code { get; set; }
            /// <summary>
            /// 返回说明
            /// </summary>
            public string message { get; set; }
            /// <summary>
            /// 返回数据体 可为空
            /// </summary>
            public T body { get; set; }
        }
        #endregion
    }
}
