1)clone the repo

2)install dependencies

3)change appsetting.json to you custom secrets(include connection string and stripe secrets)

4)run


initial Admin Account ==> change to your custom username and password

adminEmail = admin@admin.com
UserName = admin
Password = Admin@123


Use test card details to make a payment:
Card Number: 4242 4242 4242 4242
Expiration Date: Any future date
CVC: Any 3 digits
ZIP Code: Any value


if you run the sql dummy insertion, replace the addedbyuserid with the admin userID 


features to return to:
1) email sender and email confirmation
2) download or delete profile data
3) External Login/Register
4) images uploaded to wwwroot
5) Redis instead of in memory cache
6) Stripe Webhooks


Live Demo:
https://ecommercemyshop.runasp.net



