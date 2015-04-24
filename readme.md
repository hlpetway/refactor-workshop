#Refactor Workshop in C#
Hosted by Seattle Software Craftsmanship Meetup
https://github.com/SeattleSoftwareCraftsmanship/Zuma

###Four Rules of Simple Design:
1.) Passes all Tests
2.) Clearly expressed intent
3.) Eliminates Duplication
4.) Has fewer elements
-Kent Beck

There are a lot of differences of opinions on what are the four simple rules of design.

##Code Smells:
###Magic Numbers or Strings, or etc.
Convert to a well named variable or constants

###Ambigous Member Names
ex. GetClient(a, b){}
ex. xxxHelper

###Code Comments
easily outdated
redundant if members have expressive naming, etc.
Comments are fine if they explain why, and it better be surprising.

###Commented Out Code/Dead Code
Adds noise and leads to confusion.
Think of Expedia example with:
"remove this after R3"

###Duplication
If you find yourself making changes in more than one place for one change.
DRY - Don't Repeat Yourself
Single Responsibility Principle

##Low Complexity Refactorings
- Delete Comments
- Reformatting code
- Rename private variables/methods
- Extract variables
- Inlining variables
