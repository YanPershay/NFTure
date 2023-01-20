import HomePage from "./pages/Home.jsx";
import GalleryPage from "./pages/Gallery.jsx";
import AboutPage from "./pages/About.jsx";
import ContactsPage from "./pages/Contacts.jsx";

// TODO: divide into public and private routes after adding auth functionality
export const routes = [
    {path: "/home", component: <HomePage/>, exact: false},
    {path: "/gallery", component: <GalleryPage />, exact: false},
    {path: "/about", component: <AboutPage/>, exact: false},
    {path: "/contacts", component: <ContactsPage/>, exact: false},
]