// src/main.ts
import { importProvidersFrom } from '@angular/core';
import { bootstrapApplication } from '@angular/platform-browser';
import { provideHttpClient } from '@angular/common/http';
import { APOLLO_OPTIONS, ApolloModule } from 'apollo-angular';
import { HttpLink } from 'apollo-angular/http';
import { InMemoryCache } from '@apollo/client/core';
import { AppComponent } from './app/app.component';

const uri = 'http://localhost:5123/graphql';

function provideApollo(httpLink: HttpLink) {
  return {
    cache: new InMemoryCache(),
    link: httpLink.create({ uri }),
  };
}

bootstrapApplication(AppComponent, {
  providers: [
    provideHttpClient(),
    importProvidersFrom(ApolloModule),
    {
      provide: APOLLO_OPTIONS,
      useFactory: provideApollo,
      deps: [HttpLink],
    },
  ],
}).catch((err) => console.error(err));
