## This is an application that fulfils the following requirements:

1.	Accepts two strings as input: one string is called "text" and the other is called "subtext" in this problem statement,
2.	Matches the subtext against the text, outputting the character positions of the beginning of each match for the subtext within the text.
3.	Allows multiple matches
4.	Allows case insensitive matching

**Acceptance Criteria**

The input text is: Polly put the kettle on, polly put the kettle on, polly put the kettle on we'll all have tea

Subtext:		Polly
Output:			1, 26, 51								

Subtext: 		polly
Output: 		1, 26, 51								

Subtext: 		ll
Output: 		3, 28, 53, 78, 82							

Subtext: 		Ll
Output: 		3, 28, 53, 78, 82							

Subtext: 		X
Output: 		<no matches>								

Subtext: 		Polx
Output: 		<no matches>								
