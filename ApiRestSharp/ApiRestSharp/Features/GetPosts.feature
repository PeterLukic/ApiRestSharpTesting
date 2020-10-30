Feature: GetPosts
	Some examples for Get Post

Scenario: Get Post Test 1
	Given I perform GET operation for "posts/{postid}"
	Then I perform operation for post "1"
	And I should see the "title" name as "sunt aut facere repellat provident occaecati excepturi optio reprehenderit"

