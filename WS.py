#+JMJ+
#Paul A Maurais 

import cherrypy
import mysql.connector
import json


@cherrypy.expose
class StringGeneratorWebService(object):



    @cherrypy.tools.accept(media='text/plain')
    def GET(self):
        return "NO FXN"

    def POST(self, query):
        cnx = mysql.connector.connect(user='gordon', password='password',
                                      host='msa.cz0sfiru3pto.us-east-1.rds.amazonaws.com',
                                      database='msa')

        responseArr=list()
        cursor = cnx.cursor()
        cursor.execute(query)

        for (item) in cursor:
            responseArr.append(item)

        return json.dumps(responseArr)
        cursor.close()

        cxn.close()

    def PUT(self, another_string):
        return "NO FXN"

    def DELETE(self):
        return "NO FXN"


if __name__ == '__main__':


    conf = {
        '/': {
            'request.dispatch': cherrypy.dispatch.MethodDispatcher(),
            'tools.sessions.on': True,
            'tools.response_headers.on': True,
            'tools.response_headers.headers': [('Content-Type', 'text/plain')],
        }
    }
    cherrypy.config.update({'server.socket_host': '0.0.0.0'})
    cherrypy.quickstart(StringGeneratorWebService(), '/', conf)


# +JMJ+
