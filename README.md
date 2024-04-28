<!DOCTYPE html>
<html lang="en">
<head>
  <meta charset="UTF-8">
  <meta name="viewport" content="width=device-width, initial-scale=1.0">
</head>
<body>
  <h1>API Documentation</h1>

  <h2>GET /peoples</h2>
  <pre>
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
  </pre>

  <h2>POST /Peoples</h2>
  <pre>
    {
      "peopleId": 9,
      "peopleName": "Leo Högberg",
      "phoneNumber": 124578958
    }
  </pre>

  <h2>GET /peoples/{peopleId}/interests</h2>
  <p>PeopleId: 1</p>
  <pre>
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
  </pre>

  <h2>POST /peoples/{peopleId}/interests</h2>
  <p>PeopleId: 4</p>
  <pre>
    {
      "personName": "Linda Bergman",
      "interest": {
        "interestId": 10,
        "title": "Boat",
        "description": "Go boating in the summer"
      }
    }
  </pre>

  <h2>GET /interests</h2>
  <pre>
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
  </pre>

  <h2>POST /interests</h2>
  <pre>
    {
      "interestId": 11,
      "title": "Concerts",
      "description": "Go to concerts and listen to good music live"
    }
  </pre>

  <h2>POST /people/{peopleId}/interests/{interestId}</h2>
  <p>PeopleId: 3, InterestId: 4</p>
  <pre>
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
  </pre>

  <h2>GET /links</h2>
  <pre>
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
  </pre>

  <h2>POST /links</h2>
  <pre>
    {
      "linkId": 15,
      "website": "https://www.google.se/",
      "interestId": 5,
      "interests": null
    }
  </pre>

  <h2>GET /peoples/{peopleId}/links</h2>
  <pre>
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
  </pre>

</body>
</html>
