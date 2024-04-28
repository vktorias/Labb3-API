GET/peoples
[
  {
    "peopleId": 1,
    "peopleName": "Viktoria Wallström",
    "phoneNumber": 123456789
  },
  {
    "peopleId": 2,
    "peopleName": "Viktor Nordlund",
    "phoneNumber": 123456853
  },
  {
    "peopleId": 3,
    "peopleName": "Karolin Larsson",
    "phoneNumber": 123589647
  },
  {
    "peopleId": 4,
    "peopleName": "Linda Bergman",
    "phoneNumber": 521485452
  },
  {
    "peopleId": 5,
    "peopleName": "Gabriel Hermansson",
    "phoneNumber": 659842725
  },
  {
    "peopleId": 6,
    "peopleName": "Ylwa Berg",
    "phoneNumber": 124569852
  },
  {
    "peopleId": 7,
    "peopleName": "Jonas Berg",
    "phoneNumber": 124569845
  },
  {
    "peopleId": 8,
    "peopleName": "Ian Borgsjö",
    "phoneNumber": 45612318
  }
]
POST/Peoples
{
  "peopleId": 9,
  "peopleName": "Leo Högberg",
  "phoneNumber": 124578958
}
GET/peoples/{peopleId}/interests
PeopleId: 1
[
  {
    "personName": "Viktoria Wallström",
    "interestTitle": "Gym",
    "interestDescription": "Lift weights"
  },
  {
    "personName": "Viktoria Wallström",
    "interestTitle": "Running",
    "interestDescription": "Run in the forest with music in ears"
  }
]
POST/peoples/{peopleId}/interests
PeopleId: 4
{
  "personName": "Linda Bergman",
  "interest": {
    "interestId": 10,
    "title": "Boat",
    "description": "Go boating in the summer"
  }
}
GET/interests
[
  {
    "interestId": 1,
    "title": "Gym",
    "description": "Lift weights"
  },
  {
    "interestId": 2,
    "title": "Fishing",
    "description": "Fishing with a casting rod"
  },
  {
    "interestId": 3,
    "title": "Gaming",
    "description": "Play games on TV/computer"
  },
  {
    "interestId": 4,
    "title": "Programming",
    "description": "Solve problems with code"
  },
  {
    "interestId": 5,
    "title": "Dancing",
    "description": "Tango"
  },
  {
    "interestId": 6,
    "title": "Sing",
    "description": "In the shower"
  },
  {
    "interestId": 7,
    "title": "Painting",
    "description": "Paint with beautiful colors"
  },
  {
    "interestId": 8,
    "title": "Garden",
    "description": "planting flowers"
  },
  {
    "interestId": 9,
    "title": "Running",
    "description": "Run in the forest with music in ears"
  },
  {
    "interestId": 10,
    "title": "Boat",
    "description": "Go boating in the summer"
  }
]
POST/interests
{
  "interestId": 11,
  "title": "Concerts",
  "description": "Go to concerts and listen to good music live"
}
POST/people/{peopleId}/interests/{interestId}
peopleId: 3
interestId: 4
{
  "peopleInterestId": 15,
  "peopleId": 3,
  "people": {
    "peopleId": 3,
    "peopleName": "Karolin Larsson",
    "phoneNumber": 123589647
  },
  "interestId": 4,
  "interest": {
    "interestId": 4,
    "title": "Programming",
    "description": "Solve problems with code"
  }
}
GET/links
[
  {
    "linkId": 5,
    "website": "https://www.facebook.com/viktoria.wallstrom/",
    "interestId": 1,
    "interests": null
  },
  {
    "linkId": 6,
    "website": "https://en.wikipedia.org/wiki/Fishing_rod",
    "interestId": 2,
    "interests": null
  },
  {
    "linkId": 7,
    "website": "https://www.mabra.com/traning/traningsmotivation-experter-tips/7147958",
    "interestId": 1,
    "interests": null
  },
  {
    "linkId": 8,
    "website": "https://www.gamesgames.com/",
    "interestId": 3,
    "interests": null
  },
  {
    "linkId": 9,
    "website": "https://en.wikipedia.org/wiki/Computer_programming",
    "interestId": 4,
    "interests": null
  },
  {
    "linkId": 10,
    "website": "https://www.youtube.com/watch?v=mBmGNTkr1Nk&ab_channel=CordlessMusic",
    "interestId": 5,
    "interests": null
  },
  {
    "linkId": 11,
    "website": "https://www.youtube.com/watch?v=HXZZEJap3Lg&ab_channel=sympathetic",
    "interestId": 6,
    "interests": null
  },
  {
    "linkId": 12,
    "website": "https://sv.wikipedia.org/wiki/Tango",
    "interestId": 5,
    "interests": null
  },
  {
    "linkId": 13,
    "website": "https://gaminghuset.se/",
    "interestId": 3,
    "interests": null
  }
]
POST/links
{
  "linkId": 15,
  "website": "https://www.google.se/",
  "interestId": 5,
  "interests": null
}
GET/peoples/{peopleId}/links
[
  {
    "personName": "Ian Borgsjö",
    "linkUrl": "https://en.wikipedia.org/wiki/Fishing_rod"
  },
  {
    "personName": "Ian Borgsjö",
    "linkUrl": "https://www.facebook.com/viktoria.wallstrom/"
  },
  {
    "personName": "Ian Borgsjö",
    "linkUrl": "https://www.mabra.com/traning/traningsmotivation-experter-tips/7147958"
  }
]

