using Twilio;
using Twilio.Types;
using Twilio.Rest.Api.V2010.Account;
using Microsoft.Extensions.Configuration;

IConfigurationRoot configuration = new ConfigurationBuilder()
    .AddUserSecrets<Program>()
    .Build();

string twilioAccountSid = configuration["TwilioAccountSid"];
string twilioAuthToken = configuration["TwilioAuthToken"];
string twilioMessagingServiceSid = configuration["TwilioMessagingServiceSid"];


TwilioClient.Init(twilioAccountSid, twilioAuthToken);
// Send first message
var firstMessageOptions = new CreateMessageOptions(new PhoneNumber("<to number>"));
firstMessageOptions.Body = "Hi, tomorrow is a special day. So be ready for a big surprise.";
firstMessageOptions.MessagingServiceSid = twilioMessagingServiceSid;
firstMessageOptions.SendAt = DateTime.UtcNow.AddMinutes(1);
firstMessageOptions.ScheduleType = MessageResource.ScheduleTypeEnum.Fixed;

var firstMessage = MessageResource.Create(firstMessageOptions);

Console.WriteLine($"First Message SID: {firstMessage.Sid}");
Console.WriteLine($"First Message Status: {firstMessage.Status}");


// Send second message
var secondMessageOptions = new CreateMessageOptions(new PhoneNumber("<to number>"));
secondMessageOptions.Body = "Today is a special day, so at 6:00 p.m. wait at the corner of Y and X streets.";
secondMessageOptions.MessagingServiceSid = twilioMessagingServiceSid;
secondMessageOptions.SendAt = DateTime.UtcNow.AddMinutes(2);
secondMessageOptions.ScheduleType = MessageResource.ScheduleTypeEnum.Fixed;

var secondMessage = MessageResource.Create(secondMessageOptions);

Console.WriteLine($"Second Message SID: {secondMessage.Sid}");
Console.WriteLine($"Second Message Status: {secondMessage.Status}");

// Send third message
var thirdMessageOptions = new CreateMessageOptions(new PhoneNumber("<to number>"));
thirdMessageOptions.Body = "It's 11:59 pm and has been a wonderful day and I hope you have enjoyed this wonderful dinner with me.";
thirdMessageOptions.MessagingServiceSid = twilioMessagingServiceSid;
thirdMessageOptions.SendAt = DateTime.UtcNow.AddMinutes(3);
thirdMessageOptions.ScheduleType = MessageResource.ScheduleTypeEnum.Fixed;

var thirdMessage = MessageResource.Create(thirdMessageOptions);

Console.WriteLine($"Third Message SID: {thirdMessage.Sid}");
Console.WriteLine($"Third Message Status: {thirdMessage.Status}");