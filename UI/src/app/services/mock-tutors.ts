import { Tutor } from "../models/tutor/tutor";

export const TUTORS: Tutor[] = [
  {
    Id: '10',
    User: {
      Id: '1',
      FirstName: 'Emily',
      LastName: 'Dalton',
      Email: 'edalton@hotmail.com',
      UserName: 'emily.dalton',
      Topics: ['welding', 'hvac', 'home improvement, science'],
      Location: {
        Longitude: -117.969350,
        Latitude: 33.909460
      }
    },
    About: 'Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Varius morbi enim nunc faucibus a. Risus at ultrices mi tempus imperdiet nulla malesuada pellentesque. Quis auctor elit sed vulputate mi sit amet mauris.',
    HourlyRate: 57.33,
    DegreesOrCerts: [
      {
        Title: 'HVAC Certificate',
        Details: 'Completed HVAC training at HVAC Institute'
      },
      {
        Title: 'Welding Certificate',
        Details: 'Completed welding training at Welding College'
      }
    ],
    Rating: 4.5
  },

  {
    Id: '11',
    User: {
      Id: '2',
      FirstName: 'Dustin',
      LastName: 'Herrera',
      Email: 'dherrera@qq.com',
      UserName: 'dustin.herrera',
      Topics: ['finance', 'real estate investing', 'economics, math'],
      Location: {
        Longitude: -79.546600,
        Latitude: 43.099530
      }
    },
    About: 'Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Faucibus turpis in eu mi bibendum neque egestas. Velit scelerisque in dictum non. Adipiscing diam donec adipiscing tristique.',
    HourlyRate: 88.95,
    DegreesOrCerts: [
      {
        Title: 'Bachelors of Science in Finance',
        Details: 'Completed finance degree and Finance University'
      },
      {
        Title: 'Real Estate License',
        Details: 'Completed real estate license last Thursday'
      }
    ],
    Rating: 8.5
  },

  {
    Id: '12',
    User: {
      Id: '3',
      FirstName: 'Muhammad',
      LastName: 'Salazar',
      Email: 'msalazar@gmail.com',
      UserName: 'muhammad.salazar',
      Topics: ['materials science', 'thin films science', 'physics', 'math', 'engineering' ],
      Location: {
        Longitude: -122.964410,
        Latitude: 39.469350
      }
    },
    About: 'Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Sit amet justo donec enim diam vulputate ut pharetra. In ante metus dictum at tempor commodo ullamcorper a lacus. Malesuada bibendum arcu vitae elementum curabitur. Sollicitudin aliquam ultrices sagittis orci a.',
    HourlyRate: 38.55,
    DegreesOrCerts: [
      {
        Title: 'Masters in Science',
        Details: 'Concentration in materials and thin films'
      }
    ],
    Rating: 3.8
  },

  {
    Id: '13',
    User: {
      Id: '4',
      FirstName: 'Demi-Lee',
      LastName: 'Wise',
      Email: 'dwise@yahoo.com',
      UserName: 'demilee.wise',
      Topics: ['marketing', 'literature', 'english', 'literature', 'poetry', 'history'],
      Location: {
        Longitude: -117.049880,
        Latitude: 32.610010
      }
    },
    About: 'Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Tincidunt augue interdum velit euismod in pellentesque massa placerat. Lobortis mattis aliquam faucibus purus in massa tempor nec. A iaculis at erat pellentesque adipiscing commodo elit at. Pulvinar elementum integer enim neque volutpat ac tincidunt vitae semper. Urna molestie at elementum eu facilisis sed odio morbi.',
    HourlyRate: 63.27,
    DegreesOrCerts: [
      {
        Title: 'Bachelors of Arts in Marketing',
        Details: 'Completed degree at Marketing University with a minor in literature'
      }
    ],
    Rating: 8.3
  },

  {
    Id: '14',
    User: {
      Id: '5',
      FirstName: 'Sammy',
      LastName: 'Horton',
      Email: 'shorton@outlook.com',
      UserName: 'sammy.horton',
      Topics: ['law', 'political science', 'english', 'literature'],
      Location: {
        Longitude: -91.914050,
        Latitude: 50.094660
      }
    },
    About: 'Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Tortor aliquam nulla facilisi cras fermentum odio eu feugiat pretium. Sagittis vitae et leo duis ut. Suspendisse potenti nullam ac tortor vitae. Metus vulputate eu scelerisque felis imperdiet proin fermentum leo.',
    HourlyRate: 100.47,
    DegreesOrCerts: [
      {
        Title: 'Master of Arts Political Science',
        Details: 'Completed Degree at Political Science College'
      },
      {
        Title: 'Master of Arts in Law',
        Details: 'Completed Degree at Law Institute'
      }
    ],
    Rating: 9.9
  }

];
