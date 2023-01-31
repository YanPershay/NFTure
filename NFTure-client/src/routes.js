import HomePage from "./pages/home/Home.jsx";
import GalleryPage from "./pages/gallery/Gallery.jsx";
import AboutPage from "./pages/about/About.jsx";
import ContactsPage from "./pages/contacts/Contacts.jsx";

// TODO: divide into public and private routes after adding auth functionality
export const routes = [
    {path: "/home", component: <HomePage/>, exact: false},
    {path: "/gallery", component: <GalleryPage />, exact: false},
    {path: "/about", component: <AboutPage/>, exact: false},
    {path: "/contacts", component: <ContactsPage/>, exact: false},
]