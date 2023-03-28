using System;

namespace RedditFullStack_main.model
{
    



	public class User
	{
		public long UserId { get; set; }
		public string Name { get; set; }

		public User(string name)
		{
			this.Name = name;
            
		}

	}
}


