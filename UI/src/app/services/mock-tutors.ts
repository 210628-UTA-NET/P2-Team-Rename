import { Tutor } from "../models/tutor/tutor";

export const TUTORS: Tutor[] = [
  {
    id: '10',
      firstName: 'Emily',
      lastName: 'Dalton',
      email: 'edalton@hotmail.com',
      userName: 'emily.dalton',
      topics: ['welding', 'hvac', 'home improvement', 'science'],
      location: {
        longitude: -117.969350,
        latitude: 33.909460
      },
    about: 'Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Varius morbi enim nunc faucibus a. Risus at ultrices mi tempus imperdiet nulla malesuada pellentesque. Quis auctor elit sed vulputate mi sit amet mauris.',
    hourlyRate: 57.33,
    degreesOrCerts: [
      {
        title: 'HVAC Certificate',
        details: 'Completed HVAC training at HVAC Institute'
      },
      {
        title: 'Welding Certificate',
        details: 'Completed welding training at Welding College'
      }
    ],
    rating: 4.5
  },

  {
    id: '11',
      firstName: 'Dustin',
      lastName: 'Herrera',
      email: 'dherrera@qq.com',
      userName: 'dustin.herrera',
      topics: ['finance', 'real estate investing', 'economics', 'math'],
      location: {
        longitude: -79.546600,
        latitude: 43.099530
      },
    about: 'Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Faucibus turpis in eu mi bibendum neque egestas. Velit scelerisque in dictum non. Adipiscing diam donec adipiscing tristique.',
    hourlyRate: 88.95,
    degreesOrCerts: [
      {
        title: 'Bachelors of Science in Finance',
        details: 'Completed finance degree and Finance University'
      },
      {
        title: 'Real Estate License',
        details: 'Completed real estate license last Thursday'
      }
    ],
    rating: 8.5
  },

  {
    id: '12',
      firstName: 'Muhammad',
      lastName: 'Salazar',
      email: 'msalazar@gmail.com',
      userName: 'muhammad.salazar',
      topics: ['materials science', 'thin films science', 'physics', 'math', 'engineering' ],
      location: {
        longitude: -122.964410,
        latitude: 39.469350
      },
    about: 'Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Sit amet justo donec enim diam vulputate ut pharetra. In ante metus dictum at tempor commodo ullamcorper a lacus. Malesuada bibendum arcu vitae elementum curabitur. Sollicitudin aliquam ultrices sagittis orci a.',
    hourlyRate: 38.55,
    degreesOrCerts: [
      {
        title: 'Masters in Science',
        details: 'Concentration in materials and thin films'
      }
    ],
    rating: 9.8
  },

  {
    id: '13',
      firstName: 'Demi-Lee',
      lastName: 'Wise',
      email: 'dwise@yahoo.com',
      userName: 'demilee.wise',
      topics: ['marketing', 'literature', 'english', 'literature', 'poetry', 'history'],
      location: {
        longitude: -117.049880,
        latitude: 32.610010
      },
    about: 'Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Tincidunt augue interdum velit euismod in pellentesque massa placerat. Lobortis mattis aliquam faucibus purus in massa tempor nec. A iaculis at erat pellentesque adipiscing commodo elit at. Pulvinar elementum integer enim neque volutpat ac tincidunt vitae semper. Urna molestie at elementum eu facilisis sed odio morbi.',
    hourlyRate: 63.27,
    degreesOrCerts: [
      {
        title: 'Bachelors of Arts in Marketing',
        details: 'Completed degree at Marketing University with a minor in literature'
      }
    ],
    rating: 9.9
  },

  {
    id: '14',
      firstName: 'Sammy',
      lastName: 'Horton',
      email: 'shorton@outlook.com',
      userName: 'sammy.horton',
      topics: ['law', 'political science', 'english', 'literature'],
      location: {
        longitude: -91.914050,
        latitude: 50.094660
      },
    about: 'Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Tortor aliquam nulla facilisi cras fermentum odio eu feugiat pretium. Sagittis vitae et leo duis ut. Suspendisse potenti nullam ac tortor vitae. Metus vulputate eu scelerisque felis imperdiet proin fermentum leo.',
    hourlyRate: 100.47,
    degreesOrCerts: [
      {
        title: 'Master of Arts Political Science',
        details: 'Completed Degree at Political Science College'
      },
      {
        title: 'Master of Arts in Law',
        details: 'Completed Degree at Law Institute'
      }
    ],
    rating: 8.3
  }

];
