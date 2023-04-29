# TanpooshStore-WebApplication
پروژه تحت وب توسعه یافته بواسطه ASP.NET Core با معماری Clean
این پروژه با معماری Clean  دارای سه لایه بصورت مجزا می باشد :
لایه مربوط به Entity های پایگاه داده : TanpooshStore.Domain
لایه مربوط به Interface های مرتبط با DatabaseContext و Business Logic ها و Service های مربوط به لایه Presentation : TanpooshStore.Application
لایه مربوط به اتصال مستقیم به پایگاه داده و ثبت Entity ها در جدول های مشخص و همچنین بخش Presentation یا EndPoint سایت که شامل قرارداد های مربوط به کاربران می باشد.
این لایه شامل این بخش هاست : TanpooshStore.Infrastructure , TanpooshStore.Presistence , EndPoint.Site
