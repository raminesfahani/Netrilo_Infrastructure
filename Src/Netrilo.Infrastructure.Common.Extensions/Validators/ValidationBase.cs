using PhoneNumbers;

namespace Infrastructure.Common.Extensions.Validators
{
    public static class ValidationBase
    {
        /// <summary>
        /// Validate a mobile number from ulong source and ensure it is either MOBILE or FIXED_LINE_OR_MOBILE
        /// </summary>
        /// <param name="mobile"></param>
        /// <returns></returns>
        public static bool IsValidMobileNumber(ulong mobile)
        {
            PhoneNumberUtil phoneNumberUtil = PhoneNumberUtil.GetInstance();
            string e164PhoneNumber = $"+{mobile}";
            PhoneNumber phoneNumber;
            try
            {
                phoneNumber = phoneNumberUtil.Parse(e164PhoneNumber, null);
            }
            catch
            {
                return false;
            }

            PhoneNumberType type = phoneNumberUtil.GetNumberType(phoneNumber);
            if (type != PhoneNumberType.MOBILE && type != PhoneNumberType.FIXED_LINE_OR_MOBILE)
                return false;

            return true;
        }
    }
}
