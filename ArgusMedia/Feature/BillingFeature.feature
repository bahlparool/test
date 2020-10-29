Feature: To verify the Food Bill and Service Charger returned by the API


Scenario Outline: ADD total food bill
	Given I have received an order
	| Starters | Mains | Drinks |
	| 4        | 4     | 4      |
	Then the API should return the correct bill
	| Total Food Bill	| Total Service Charge	| Total Bill |
	| 54		        | 5.4					| 59.4       |

Scenario Outline: UPDATE total food bill
	Given I have received an order
	| Starters | Mains | Drinks |
	| 1        | 2     | 0      |
	Then the API should return the correct bill
	| Total Food Bill	| Total Service Charge	| Total Bill |
	| 	18				|     1.8				| 19.8		 |
	When the order is updated
	| Starters | Mains | Drinks |
	| 1        | 4     | 0      |
	Then the API should return the correct bill
	| Total Food Bill	| Total Service Charge	| Total Bill |
	| 	32				|     3.2				| 35.2		 |

Scenario Outline: DELETE from total food bill
	Given I have received an order
	| Starters | Mains | Drinks |
	| 4        | 4     | 4      |
	Then the API should return the correct bill
	| Total Food Bill	| Total Service Charge	| Total Bill |
	| 54		        | 5.4					| 59.4       |
	When an order is cancelled
	| Starters | Mains | Drinks |
	| 1        | 1     | 1      |
	Then the API should return the correct bill
	| Total Food Bill	| Total Service Charge	| Total Bill |
	| 40.5		        | 4.05					| 44.55      |