export default {
  // Global page headers: https://go.nuxtjs.dev/config-head
  head: {
    title: "DienmayShop.WebClient",
    htmlAttrs: {
      lang: "en",
    },
    meta: [
      { charset: "utf-8" },
      { name: "viewport", content: "width=device-width, initial-scale=1" },
      { hid: "description", name: "description", content: "" },
      { name: "format-detection", content: "telephone=no" },
    ],
    link: [
      { rel: "icon", type: "image/x-icon", href: "/favicon.ico" },
      {
        rel: "stylesheet",
        type: "text/css",
        href: "/styles/css/bootstrap.css",
      },
      {
        rel: "stylesheet",
        type: "text/css",
        href: "/styles/css/ui.css",
      },
      {
        rel: "stylesheet",
        type: "text/css",
        href: "/styles/css/responsive.css",
      },
      {
        rel: "stylesheet",
        type: "text/css",
        href: "/fonts/fontawesome/css/all.min.css",
      },
    ],
    script: [
      {
        type: 'module',
        src: '/js/bootstrap.bundle.min.js'
      },
      {
        type: 'module',
        src: '/js/script.js?v=2.0'
      }
    ]
  },
  // Global CSS: https://go.nuxtjs.dev/config-css
  css: [],

  // Plugins to run before rendering page: https://go.nuxtjs.dev/config-plugins
  plugins: [],

  // Auto import components: https://go.nuxtjs.dev/config-components
  components: true,

  // Modules for dev and build (recommended): https://go.nuxtjs.dev/config-modules
  buildModules: [],

  // Modules: https://go.nuxtjs.dev/config-modules
  modules: [
    // https://go.nuxtjs.dev/axios
    "@nuxtjs/axios",
  ],

  // Axios module configuration: https://go.nuxtjs.dev/config-axios
  axios: {
    // Workaround to avoid enforcing hard-coded localhost:3000: https://github.com/nuxt-community/axios-module/issues/308
    baseURL: "/",
  },

  // Build Configuration: https://go.nuxtjs.dev/config-build
  build: {},
};