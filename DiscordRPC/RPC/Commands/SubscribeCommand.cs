﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DiscordRPC.RPC.Payload;
using Newtonsoft.Json;

namespace DiscordRPC.RPC.Commands
{
	internal class SubscribeCommand : ICommand
	{
		[JsonIgnore]
		public ServerEvent Event { get; set; }

		[JsonIgnore]
		public bool IsUnsubscribe { get; set; }

		public IPayload PreparePayload(long nonce)
		{
			return new SubscriptionPayload(this, nonce)
			{
				Command = IsUnsubscribe ? Command.Unsubscribe : Command.Subscribe,
				Event = Event
			};
		}
	}
}
