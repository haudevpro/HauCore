#region  ******** Copyright © 2016 HauCore ********
using System;
using System.Collections.Generic;
#endregion  ******** Copyright © 2016 HauCore ********

namespace HauCore.Attributes.Validators
{
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false)]
    public abstract class ValidatorAttribute: Attribute
    { /// <summary>
      /// Thứ tự validate
      /// </summary>
        public int Stt { set; get; }

        private object value;
        /// <summary>
        /// Giá trị cần validate
        /// </summary>
        protected object Value
        {
            get { return this.value; }
        }

        private string fieldName = string.Empty;
        /// <summary>
        /// Tên thật của một Field
        /// </summary>
        protected string FieldName
        {
            get { return fieldName; }
        }

        public Type ObjectType { set; get; }

        /// <summary>
        /// 
        /// </summary>
        public Dictionary<string, object> Data { set; get; }

        /// <summary>
        /// Thiết lập Data
        /// </summary>
        /// <param name="value"></param>
        /// <param name="objectValidate"></param>
        public void SetData(object value, string fieldName)
        {
            // Value cần validate
            this.value = value;

            // Field Name
            this.fieldName = fieldName;
        }

        /// <summary>
        /// Thực hiện validate
        /// </summary>
        /// <returns></returns>
        public abstract bool Validate();

        /// <summary>
        /// Câu thông báo
        /// </summary>
        /// <returns></returns>
        public abstract string GetMessage();
    }
    /// <summary>
    /// Các kiểu trạng thái sau khi validate
    /// </summary>
    public enum ValidatorStatus
    {
        /// <summary>
        /// Dữ liệu được validate thành công
        /// </summary>
        /// 
        Valid = 0,

        /// <summary>
        /// Dữ liệu không hợp lệ với validate
        /// </summary>
        InValid = 1
    }

    /// <summary>
    /// Đối tượng đóng gói thông báo sau khi validate
    /// </summary>
    public class ValidatorMessage
    {
        /// <summary>
        /// Trạng thái sau khi vaidate
        /// </summary>
        public ValidatorStatus Status { set; get; }

        /// <summary>
        /// Message thông báo
        /// </summary>
        public string Message { set; get; }

        /// <summary>
        /// Trường validate
        /// </summary>
        public string FieldName { set; get; }

        /// <summary>
        /// Có Valid hay không
        /// </summary>
        /// <returns></returns>
        public bool IsValid
        {
            get
            {
                return Status == ValidatorStatus.Valid;
            }
        }

        /// <summary>
        /// Default
        /// </summary>
        /// <returns></returns>
        public static ValidatorMessage GetDefault()
        {
            return new ValidatorMessage { Status = ValidatorStatus.Valid, Message = "Validated" };
        }
    }

    /// <summary>
    /// ValidatorException
    /// </summary>
    public class ValidatorException : Exception
    {
        private ValidatorMessage validatorMessage = null;
        /// <summary>
        /// 
        /// </summary>
        public ValidatorMessage ValidatorMessage
        {
            get { return validatorMessage; }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="validatorMessage"></param>
        public ValidatorException(ValidatorMessage validatorMessage) : base(validatorMessage.Message)
        {
            this.validatorMessage = validatorMessage;
        }

        public ValidatorException(string fieldName, string message) : base(message)
        {
            this.validatorMessage = new ValidatorMessage
            {
                FieldName = fieldName,
                Message = message,
                Status = ValidatorStatus.InValid
            };
        }
    }
}
